using ARCSoftFaceApp.Util;
using LibHKCamera;
using LibHKCamera.HKNetWork;
using LibHKCamera.HKPlayCtrlSDK;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARCSoftFaceApp.Entity
{
    /// <summary>
    /// 摄像机
    /// </summary>
    public class Camera
    {
        public delegate void ParamItemChangedHandler();
        public event ParamItemChangedHandler ParamItemChangedEvent;
        public enum CameraStatue
        {
            [Description("未登录")]
            SignOut,
            [Description("已登录")]
            SignIn,
            [Description("正在预览")]
            OnReadPlay,
            [Description("停止预览")]
            StopReadPlay
        };
        private string ip;
        public string Ip 
        {
            get { return ip; }
            set 
            { 
                ip = value;
                ParamItemChangedEvent?.Invoke();
            }
        }
        public ushort port { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public int ChannelNum { get; set; }
        public int m_lUserId{get;set;}
        public int m_lReadHandle { get; set; }
        private int m_lPort;

        public PictureBox PictrueBoxId { get; set; }

        private ConcurrentQueue<Bitmap> queueVideoFrame;

        public IntPtr m_ptrReadHandle { get; set; }

        private CameraStatue statue;
        public CameraStatue Statue 
        { 
            get { return statue; } 
            set 
            { 
                statue = value;
                ParamItemChangedEvent?.Invoke();
            }
        }

        private ImageCover imageCover;

        public HKNetSDKS.NET_DVR_USER_LOGIN_INFO struLogInfo;

        public HKNetSDKS.NET_DVR_DEVICEINFO_V40 DeviceInfo;

        public HKNetSDKS.REALDATACALLBACK ReadData = null;
        public HKPlayCtrlSDK.DECCBFUN m_fDisplayFun = null;

        private Task taskStartRealPlay;
        private Task taskDetalDisplay;
        private CancellationTokenSource cancelTokenDetalDisplay;

        private FaceVideoRecognizer faceVideoRecognizer;

        public Camera()
        {
            ip = "192.168.0.103";
            user = "admin";
            pwd = "HikZTTXNQ";
            port = 8000;

            m_lReadHandle = -1;
            m_lUserId = -1;
            m_lPort = -1;
            PictrueBoxId = null;

            ChannelNum = 1;

            imageCover = new ImageCover();
            faceVideoRecognizer = new FaceVideoRecognizer();
            faceVideoRecognizer.initFaceEngine();
        }

        public Camera(string ip, ushort port, string user, string pwd)
            :this()
        {
            this.Ip = ip;
            this.port = port;
            this.user = user;
            this.pwd = pwd;

            Statue = CameraStatue.SignOut;
        }


        public void StartViewPlay()
        {
            if(queueVideoFrame==null)
            {
                queueVideoFrame = new ConcurrentQueue<Bitmap>();
            }

            if(cancelTokenDetalDisplay==null)
            {
                cancelTokenDetalDisplay = new CancellationTokenSource();
            }

            if (taskStartRealPlay==null)
            {
                taskStartRealPlay = Task.Factory.StartNew(RealPreview);
            }

            if (taskDetalDisplay == null)
            {
                taskDetalDisplay = Task.Factory.StartNew(DetalDisplay);
            }
        }

        public void StopViewPlay()
        {
            StopRealPreview();

            SignOutCamera();
        }

        private bool isRGBLock = false;

        public void DetalDisplay()
        {
            while (true)
            {
                if(cancelTokenDetalDisplay.Token.IsCancellationRequested)
                {
                    break;
                }

                Bitmap nowFrame;

                //如果有有效的bgr位图像则进行人工智能工作和picturView的显示
                if(queueVideoFrame.TryDequeue(out nowFrame))
                {
                    List<FaceInfo> faceInfos = faceVideoRecognizer.ScanFaces(nowFrame);

                    if (isRGBLock == false)
                    {
                        isRGBLock = true;

                        faceVideoRecognizer.ScanFaceFeature(nowFrame, ref faceInfos);


                        using (Graphics graphics = Graphics.FromImage(nowFrame))
                        {
                            for (int i = 0; i < faceInfos.Count; i++)
                            {
                                float x = faceInfos[i].singleFaceInfo.faceRect.left;
                                float width = faceInfos[i].singleFaceInfo.faceRect.right - x;
                                float y = faceInfos[i].singleFaceInfo.faceRect.top;
                                float height = faceInfos[i].singleFaceInfo.faceRect.bottom - y;

                                graphics.DrawRectangle(Pens.Red, x, y, width, height);
                            }
                        }

                        for(int i=0;i<faceInfos.Count;i++)
                        {
                            faceInfos[i].Dispose();
                            faceInfos[i] = null;
                        }

                        faceInfos.Clear();
                        faceInfos = null;
                        isRGBLock = false;
                    }

                    //显示到屏幕中
                    if (PictrueBoxId!=null)
                    {
                        PictrueBoxId.Image.Dispose();
                        PictrueBoxId.Image = nowFrame;
                    }
                }

                GC.Collect();
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 根据保存的ip地址，用户名，密码等信息
        /// </summary>
        public int SignCamera()
        {
            if(!this.checkSignParam())
            {
                //检测出用于登录的参数有问题
                return -1;
            }

            //该摄像机未登录
            if(Statue==CameraStatue.SignOut)
            {
                //初始化登录信息结构体
                struLogInfo = new HKNetSDKS.NET_DVR_USER_LOGIN_INFO();

                //复制IP地址到结构体中
                byte[] byIp = System.Text.Encoding.Default.GetBytes(Ip);
                struLogInfo.sDeviceAddress = new byte[129];
                byIp.CopyTo(struLogInfo.sDeviceAddress, 0);

                //复制用户名到登录结构体中
                byte[] byUser = System.Text.Encoding.Default.GetBytes(user);
                struLogInfo.sUserName = new byte[64];
                byUser.CopyTo(struLogInfo.sUserName, 0);

                //复制登录密码到登录结构体中
                byte[] byPwd = System.Text.Encoding.Default.GetBytes(pwd);
                struLogInfo.sPassword = new byte[64];
                byPwd.CopyTo(struLogInfo.sPassword, 0);

                //复制端口号到登录结构体中
                struLogInfo.wPort = port;

                DeviceInfo = new HKNetSDKS.NET_DVR_DEVICEINFO_V40();

                //尝试登录设备，如果登录成功，则返回值会大于等于0,在这里使用的是同步登陆方式，会所在线程进进入阻塞状态
                m_lUserId = HKNetSDKS.NET_DVR_Login_V40(ref struLogInfo, ref DeviceInfo);

                //登录设备，并获取设备信息，当登录失败，该
                if (m_lUserId<0)
                {

                    //获取错误代码，并返回改错误代码
                    LoggerService.logger.Error($"摄像IP：{ip} 登录失败[{HKNetSDKS.NET_DVR_GetLastError()}]!");
                    return (int)HKNetSDKS.NET_DVR_GetLastError();
                }
                //登录成功
                else
                {
                    Statue = CameraStatue.SignIn;

                    LoggerService.logger.Info($"摄像IP：{ip} 登录成功！");
                }
            }
            return 0;
        }

        public int SignOutCamera()
        {
            if(m_lReadHandle>=0)
            {
                LoggerService.logger.Info($"摄像IP：{ip} 请先停止预览!");
                return -2;
            }

            if(!HKNetSDKS.NET_DVR_Logout(m_lUserId))
            {
                LoggerService.logger.Error($"摄像IP：{ip} 注销失败[{HKNetSDKS.NET_DVR_GetLastError()}]!");
                return -3;
            }

            LoggerService.logger.Info($"摄像IP：{ip} 注销 成功！");

            m_lUserId = -1;

            if((taskStartRealPlay != null) && (taskStartRealPlay.IsCompleted))
            {
                taskStartRealPlay = null;
            }

            Statue = CameraStatue.SignOut;

            return 0;
        }

        /// <summary>
        /// 执行进行监控预览
        /// </summary>
        /// <returns>-2：启动预览错误；-1：设备未登录，0：执行正常</returns>
        public int RealPreview()
        {
            //如果设备未登录
            if(m_lUserId<0)
            {
                LoggerService.logger.Info("请先登录该网络视频设备后再预览!");
                return -1;
            }

            //如果没有创建过预览句柄
            //则进行预览设置
            if(m_lReadHandle<0)
            {
                HKNetSDKS.NET_DVR_PREVIEWINFO lpPreviewInfo = new HKNetSDKS.NET_DVR_PREVIEWINFO();

                lpPreviewInfo.hPlayWnd = IntPtr.Zero;
                lpPreviewInfo.lChannel = ChannelNum;
                lpPreviewInfo.dwStreamType = 0;//主码流
                lpPreviewInfo.dwLinkMode = 0;//TCP方式
                lpPreviewInfo.bBlocked = true;//阻塞式
                lpPreviewInfo.dwDisplayBufNum = 15;//播放库显示缓存区最大的帧数

                IntPtr pUser = IntPtr.Zero;

                ReadData = new HKNetSDKS.REALDATACALLBACK(RealDataCallBack);
                m_lReadHandle = HKNetSDKS.NET_DVR_RealPlay_V40(m_lUserId, ref lpPreviewInfo, ReadData, pUser);

                if(m_lReadHandle<0)
                {
                    LoggerService.logger.Error($"摄像头{ip}，启动预览失败，错误代码：{HKNetSDKS.NET_DVR_GetLastError()}");
                    return -2;
                }
                else
                {
                    LoggerService.logger.Info($"摄像头{ip}，启动预览成功！");
                    Statue = CameraStatue.OnReadPlay;
                }
            }

            return 0;
        }

        public int StopRealPreview()
        {
            if(m_lReadHandle<0)
            {
                LoggerService.logger.Error($"摄像头{ip}，未启动过预览。");
                return -1;
            }

            if(!HKNetSDKS.NET_DVR_StopRealPlay(m_lReadHandle))
            {
                LoggerService.logger.Error($"摄像头{ip}，播放器无法停止预览。错误代码：{HKNetSDKS.NET_DVR_GetLastError()}");
            }

            if (m_lPort>=0)
            {
                if(!HKPlayCtrlSDK.PlayM4_Stop(m_lPort))
                {
                     LoggerService.logger.Error($"摄像头{ip}，播放器无法停止工作。错误代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                }

                if(!HKPlayCtrlSDK.PlayM4_CloseStream(m_lPort))
                {
                    LoggerService.logger.Error($"摄像头{ip}，播放器无法关闭数据流。错误代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                }
                if(!HKPlayCtrlSDK.PlayM4_FreePort(m_lPort))
                {
                    LoggerService.logger.Error($"摄像头{ip}，播放器无法释放播放端口。错误代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                }

                m_lPort = -1;
            }

            cancelTokenDetalDisplay.Cancel();

            if (taskDetalDisplay.IsCompleted)
            {
                taskDetalDisplay = null;
                cancelTokenDetalDisplay = null;
            }

            LoggerService.logger.Info($"摄像头{ip}，已停止预览。");

            m_lReadHandle = -1;
            Statue = CameraStatue.StopReadPlay;
            if (PictrueBoxId != null)
            {
                PictrueBoxId.Invalidate();
                PictrueBoxId = null;
            }
            return 0;
        }

        public void RealDataCallBack(int lReadHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            switch (dwDataType)
            {
                case GloableVar.NET_DVR_SYSHEAD:
                    {
                        if(dwBufSize>0)
                        {
                            if(m_lPort>=0)
                            {
                                return;
                            }

                            //获取播放器句柄
                            if(!HKPlayCtrlSDK.PlayM4_GetPort(ref m_lPort))
                            {
                                LoggerService.logger.Error($"摄像头{ip},获取播放句柄错误 代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                                break;
                            }

                            //设置流播放模式
                            if(!HKPlayCtrlSDK.PlayM4_SetStreamOpenMode(m_lPort, GloableVar.STREAME_REALTIME))
                            {
                                LoggerService.logger.Error($"摄像头{ip},设置播放流错误 代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                                
                            }

                            //打开码流，送入头数据 1080P视频流建议开到6M的缓存
                            if(!HKPlayCtrlSDK.PlayM4_OpenStream(m_lPort,pBuffer,dwBufSize, 6*1024*1024))
                            {
                                LoggerService.logger.Error($"摄像头{ip},打开播放流错误 代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                                break;
                            }

                            //设置显示缓冲区个数
                            if(!HKPlayCtrlSDK.PlayM4_SetDisplayBuf(m_lPort,15))
                            {
                                LoggerService.logger.Error($"摄像头{ip},设置显示缓存区错误 代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                                
                            }

                            //设置显示模式
                            if(!HKPlayCtrlSDK.PlayM4_SetOverlayMode(m_lPort, 0,0))
                            {
                                LoggerService.logger.Error($"摄像头{ip},设置显示属性错误 代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                            }

                            //设置解码回调函数
                            m_fDisplayFun = new HKPlayCtrlSDK.DECCBFUN(DecCallbackFUN);
                            if(!HKPlayCtrlSDK.PlayM4_SetDecCallBackEx(m_lPort,m_fDisplayFun,IntPtr.Zero, 0))
                            {
                                LoggerService.logger.Error($"摄像头{ip},设置解码回调函数错误 代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                            }

                            if (!HKPlayCtrlSDK.PlayM4_Play(m_lPort, m_ptrReadHandle))
                            {
                                LoggerService.logger.Error($"摄像头{ip},播放软件播放错误 代码：{HKPlayCtrlSDK.PlayM4_GetLastError(m_lPort)}");
                                break;
                            }

                            LoggerService.logger.Info($"摄像头{ip}，解码器运行，通道{m_lPort}");
                        }
                    }
                    break;
                case GloableVar.NET_DVR_STREAMDATA: //如果是流数据
                default:
                    {
                        if (dwBufSize > 0 && m_lPort != -1)
                        {
                            bool inData = HKPlayCtrlSDK.PlayM4_InputData(m_lPort, pBuffer, dwBufSize);
                            while(!inData)
                            {
                                Thread.Sleep(10);
                                inData = HKPlayCtrlSDK.PlayM4_InputData(m_lPort, pBuffer, dwBufSize);
                            }
                        }
                    }
                    break;
            }
        }

        private void DecCallbackFUN(int nPort, IntPtr pBuf, int nSize, ref HKPlayCtrlSDK.FRAME_INFO pFrameInfo, int nReserved1, int nReserved2)
        {
            if(pFrameInfo.nType== GloableVar.T_YV12)
            {
                Bitmap nowFramBitMap=imageCover.Yv12_2_BGR(ref pBuf, nSize, pFrameInfo.nHeight, pFrameInfo.nWidth);

                if(nowFramBitMap!=null)
                {
                    queueVideoFrame.Enqueue(nowFramBitMap);
                }
            }
        }

        /// <summary>
        /// 用来检查登录用的参数是否合法
        /// </summary>
        /// <returns></returns>
        public bool checkSignParam()
        {
            string ipAddressPattrn = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

            if(!Regex.IsMatch(Ip,ipAddressPattrn))
            {
                return false;
            }

            if(port<0 || port > 65535)
            {
                return false;
            }

            if(user==null || pwd == null || user.Length==0 || pwd.Length==0)
            {
                return false;
            }

            return true;
        }

        public string CoverCameraStatue()
        {
            return Util.EnumService.GetDescription(Statue);
        }
    }
}

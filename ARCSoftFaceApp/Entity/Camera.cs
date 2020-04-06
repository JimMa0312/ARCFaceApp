using ARCSoftFaceApp.Util;
using LibHKCamera.HKNetWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            OnReadPlay
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

        public HKNetSDKS.NET_DVR_USER_LOGIN_INFO struLogInfo;

        public HKNetSDKS.NET_DVR_DEVICEINFO_V40 DeviceInfo;

        public HKNetSDKS.REALDATACALLBACK ReadData = null;

        public Camera()
        {
            m_lReadHandle = -1;
            m_lUserId = -1;
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
                lpPreviewInfo.dwDisplayBufNum = 25;//播放库显示缓存区最大的帧数

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
                    statue = CameraStatue.OnReadPlay;
                }
            }

            return 0;
        }

        public void RealDataCallBack(int lReadHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {

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

using ARCSoftFaceApp.Controller;
using ARCSoftFaceApp.Entity;
using ARCSoftFaceApp.EntityFrameDataModel;
using ARCSoftFaceApp.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibHKCamera.HKNetWork;
using ARCSoftFaceApp.CameraManage;
using ARCSoftFaceApp.Util.ARCFace;
using ArcSoftFace.Utils;
using System.IO;
using ArcSoftFace.Models;

namespace ARCSoftFaceApp
{
    public partial class MainWindow : Form
    {
        public const int RealPlayWndWidth= 642;
        public const int RealPlayWndHeigh = 360;
        private readonly long maxSize=1024*1024*2;
        private int nowWindowxWidth;
        private int nowWindowyHeigh;
        private long iSelectedIndex;

        private List<PictureBox> realPlayList;
        private CameraControler cameraControler;
        private FaceImageRecognizer faceImageRecognizer;

        private bool m_bInitHKSDK;//标记华康SDK是否初始化成功

        public MainWindow()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            cameraControler = new CameraControler();
            iSelectedIndex = 0;
        }

        /// <summary>
        /// 根据屏幕分辨率分配预览控件
        /// 将预览显示控件注册到流布局控件中
        /// </summary>
        private void groupRealPlayWnd()
        {

            nowWindowxWidth = this.flowLayoutPanelVideoReal.Width;
            nowWindowyHeigh = this.flowLayoutPanelVideoReal.Height;

            int playRow = nowWindowyHeigh / RealPlayWndHeigh;
            int playColum = nowWindowxWidth / RealPlayWndWidth;
            int playWndCount = playRow * playColum;

            realPlayList = new List<PictureBox>();

            for (int i = 0; i < playWndCount; i++)
            {
                PictureBox tmpPictureBox = new PictureBox();
                tmpPictureBox.Name = $"PictureBoxRealPlayWnd{i}";
                tmpPictureBox.Width = RealPlayWndWidth;
                tmpPictureBox.Height = RealPlayWndHeigh;
                tmpPictureBox.BackColor = Color.Black;
                tmpPictureBox.Image=(Properties.Resources.NoSIgnalpng);
                tmpPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                realPlayList.Add(tmpPictureBox);
                this.flowLayoutPanelVideoReal.Controls.Add(tmpPictureBox);
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            groupRealPlayWnd();

            LoggerService.IniterLogService();

            //初始化海康SDK
            m_bInitHKSDK = HKNetSDKS.NET_DVR_Init();

            if (m_bInitHKSDK == false)
            {
                MessageBox.Show("海康SDK::NET_DVR_Init 初始化错误！");
                return;
            }
            else
            {
                HKNetSDKS.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }

            ARCFaceEngineUtils.InitARCFaceEngine();
            faceImageRecognizer = new FaceImageRecognizer();
            faceImageRecognizer.initFaceEngine();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// 登录摄像机
        /// 先弹出一个用于输入连接摄像机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 登录IP摄像机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Camera camera = new Camera();
            CameraManage.CameraManageForm cameraManageForm = new CameraManage.CameraManageForm(camera, realPlayList);
            
            if(DialogResult.OK== cameraManageForm.ShowDialog())
            {
                //设置成功
                cameraControler.RegistrerCameraDevice(camera, listViewVideoChannel);
            }
        }

        private void 数据库测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db=new attendance_sysEntities())
            {
                var query = from user in db.t_user orderby user.user_id select user;

                foreach (var item in query)
                {
                    MessageBox.Show($"id:{item.user_id}, name:{item.username}, pwd:{item.password}");
                }
            }
        }

        private void 日志输出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggerService.logger.Info("点击测试成功！");
        }

        private void listViewVideoChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewVideoChannel.SelectedItems.Count>0)
            {
                iSelectedIndex = listViewVideoChannel.SelectedItems[0].Index;
            }
        }

        private void listViewVideoChannel_MouseClick(object sender, MouseEventArgs e)
        {
            //点击的方式为右键的话，弹出设备的选中的面板
            if(e.Button==MouseButtons.Right)
            {
                if(iSelectedIndex>=0)
                {
                    CameraManageForm cameraManageForm = new CameraManageForm(cameraControler.cameras[(int)iSelectedIndex].camera, realPlayList);

                    cameraManageForm.Show();
                }
            }
        }
        private object regFaceLocker = new object();
        private void 从本地文件采集人脸特征ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (regFaceLocker)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "选择图片";
                openFileDialog.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";
                openFileDialog.Multiselect = false;
                openFileDialog.FileName = string.Empty;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    if(checkImage(fileName))
                    {
                        Image image = ImageUtil.readFromFile(fileName);

                        if (image.Width > 1536 || image.Height > 1536)
                        {
                            image = ImageUtil.ScaleImage(image, 1536, 1536);
                        }

                        if (image.Width % 4 != 0)
                        {
                            image = ImageUtil.ScaleImage(image, image.Width - (image.Width % 4), image.Height);
                        }

                        Bitmap bitmap = new Bitmap(image);

                        List<FaceInfo> faceInfos=faceImageRecognizer.ScanFaces(bitmap);

                        if(faceInfos.Count==1)
                        {
                            int num=faceImageRecognizer.ScanFaceFeature(bitmap,ref faceInfos);

                            if (num>0)
                            {
                                ASF_SingleFaceInfo singleFaceInfo = faceInfos[0].singleFaceInfo;
                                LoggerService.logger.Info(string.Format("已提取人脸特征值，[left:{0},right:{1},top:{2},bottom:{3},orient:{4}]", singleFaceInfo.faceRect.left, singleFaceInfo.faceRect.right, singleFaceInfo.faceRect.top, singleFaceInfo.faceRect.bottom, singleFaceInfo.faceOrient));
                            }
                            else
                            {
                                LoggerService.logger.Error("提取人脸特征失败！");
                            }
                            faceInfos[0].Dispose();
                            faceInfos[0] = null;
                            faceInfos.Clear();
                            faceInfos = null;
                        }

                        image.Dispose();
                        bitmap.Dispose();
                    }
                }
                openFileDialog.Dispose();
                GC.Collect();
            }
        }

        /// <summary>
        /// 校验图片
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private bool checkImage(string imagePath)
        {
            if (imagePath == null)
            {
                LoggerService.logger.Error("图片不存在，请确认后再导入\r\n");
                return false;
            }
            try
            {
                //判断图片是否正常，如将其他文件把后缀改为.jpg，这样就会报错
                Image image = ImageUtil.readFromFile(imagePath);
                if (image == null)
                {
                    throw new Exception();
                }
                else
                {
                    image.Dispose();
                }
            }
            catch
            {
                LoggerService.logger.Error(string.Format("{0} 图片格式有问题，请确认后再导入\r\n", imagePath));
                return false;
            }
            FileInfo fileCheck = new FileInfo(imagePath);
            if (fileCheck.Exists == false)
            {
                LoggerService.logger.Error(string.Format("{0} 不存在\r\n", fileCheck.Name));
                return false;
            }
            else if (fileCheck.Length > maxSize)
            {
                LoggerService.logger.Error(string.Format("{0} 图片大小超过2M，请压缩后再导入\r\n", fileCheck.Name));
                return false;
            }
            else if (fileCheck.Length < 2)
            {
                LoggerService.logger.Error(string.Format("{0} 图像质量太小，请重新选择\r\n", fileCheck.Name));
                return false;
            }
            return true;
        }
    }
}

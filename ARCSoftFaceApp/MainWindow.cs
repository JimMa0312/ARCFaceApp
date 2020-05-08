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
using Emgu.CV.UI;
using Emgu.CV;

namespace ARCSoftFaceApp
{
    /// <summary>
    /// 主界面控制类
    /// </summary>
    public partial class MainWindow : Form
    {
        private long iSelectedIndex;

        private List<ImageBox> realPlayList;
        private CameraControler cameraControler;

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

            realPlayList = new List<ImageBox>();

            for (int row = 0; row < flowLayoutPanelVideoReal.RowCount; row++)
            {
                for(int column=0;column<flowLayoutPanelVideoReal.ColumnCount;column++)
                {
                    ImageBox tmpPictureBox = new ImageBox();
                    tmpPictureBox.Name = $"PictureBoxRealPlayWnd{row*flowLayoutPanelVideoReal.RowCount + column}";
                    flowLayoutPanelVideoReal.Controls.Add(tmpPictureBox, row, column);
                    tmpPictureBox.Dock = DockStyle.Fill;
                    tmpPictureBox.BackColor = Color.Black;
                    tmpPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    tmpPictureBox.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
                    tmpPictureBox.Image = new Image<Emgu.CV.Structure.Rgb, byte>(Properties.Resources.NoSIgnalpng);
                    realPlayList.Add(tmpPictureBox);
                }
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
            FaceFeatureLib.LoadFaceLibrary();
            cameraControler.LoadCameraInDB(listViewVideoChannel);

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

        private void 更新人脸特征ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdataFaceWinow updataFaceWinow = new UpdataFaceWinow();

            updataFaceWinow.Show();
        }

        private void 加载人脸特征库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaceFeatureLib.LoadFaceLibrary();
        }

        private void 清除人脸特征库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaceFeatureLib.ClearFaceLibrary();
        }

        /// <summary>
        /// 释放所有资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in cameraControler.cameras)
            {
                item.camera.StopViewPlay();
            }

            cameraControler.cameras.Clear();
        }
    }
}

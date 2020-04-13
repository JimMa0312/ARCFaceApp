using ARCSoftFaceApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARCSoftFaceApp.CameraManage
{
    public partial class CameraManageForm : Form
    {
        private Camera camera;

        public List<PictureBox> PictureBoxes;

        public CameraManageForm()
        {
            InitializeComponent();

            buttonLognIn.Enabled = false;
            buttonLognOut.Enabled = false;
        }

        public CameraManageForm(Camera camera, List<PictureBox> pictureBoxes):
            this()
        {
            comboBoxViewIndex.Items.Add("无");

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                comboBoxViewIndex.Items.Add((i + 1).ToString());
            }

            PictureBoxes = pictureBoxes;

            if (camera==null)
            {
                camera = new Camera();
            }
            else
            {
                textBoxIp.Text = string.Copy(camera.Ip);
                textBoxPort.Text = camera.port.ToString();
                textBoxUser.Text = string.Copy(camera.user);
                textBoxPwd.Text = string.Copy(camera.pwd);

                if (camera.PictrueBoxId==null)
                {
                    comboBoxViewIndex.SelectedIndex = 0;
                }
                else
                {
                    comboBoxViewIndex.SelectedIndex = pictureBoxes.IndexOf(camera.PictrueBoxId) + 1;
                }
            }
            this.camera = camera;
            switch (camera.Statue)
            {
                case Camera.CameraStatue.SignOut:
                    buttonLognIn.Enabled = true;
                    buttonLognOut.Enabled = false;
                    buttonPlayReal.Enabled = false;
                    buttonStopReal.Enabled = false;
                    break;
                case Camera.CameraStatue.SignIn:
                    buttonLognIn.Enabled = false;
                    buttonLognOut.Enabled = true;
                    buttonPlayReal.Enabled = true;
                    buttonStopReal.Enabled = false;
                    break;
                case Camera.CameraStatue.OnReadPlay:
                    buttonLognIn.Enabled = false;
                    buttonLognOut.Enabled = false;
                    buttonPlayReal.Enabled = false;
                    buttonStopReal.Enabled = true;
                    break;
                case Camera.CameraStatue.StopReadPlay:
                    buttonLognIn.Enabled = false;
                    buttonLognOut.Enabled = true;
                    buttonPlayReal.Enabled = true;
                    buttonStopReal.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.camera.Ip = this.textBoxIp.Text;
            this.camera.port = UInt16.Parse(this.textBoxPort.Text);
            this.camera.user = this.textBoxUser.Text;
            this.camera.pwd = this.textBoxPwd.Text;
            this.DialogResult = DialogResult.OK;

            if(comboBoxViewIndex.SelectedIndex==0)
            {
                this.camera.PictrueBoxId = null;
            }
            else
            {
                this.camera.PictrueBoxId = PictureBoxes[comboBoxViewIndex.SelectedIndex - 1];
            }

            camera.checkSignParam();

            this.Close();
        }

        private void buttonLognIn_Click(object sender, EventArgs e)
        {
            camera.SignCamera();
            this.Close();
        }

        private void buttonLognOut_Click(object sender, EventArgs e)
        {
            camera.SignOutCamera();
            this.Close();
        }

        private void buttonPlayReal_Click(object sender, EventArgs e)
        {
            camera.StartViewPlay();
            this.Close();
        }

        private void buttonStopReal_Click(object sender, EventArgs e)
        {
            camera.StopViewPlay();
            this.Close();
        }
    }
}

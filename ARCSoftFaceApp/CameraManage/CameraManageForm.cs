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

        public CameraManageForm()
        {
            InitializeComponent();

            buttonLognIn.Enabled = false;
            buttonLognOut.Enabled = false;
        }

        public CameraManageForm(Camera camera):
            this()
        {
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
            }
            this.camera = camera;
            switch (camera.Statue)
            {
                case Camera.CameraStatue.SignOut:
                    buttonLognIn.Enabled = true;
                    buttonLognOut.Enabled = false;
                    break;
                case Camera.CameraStatue.SignIn:
                    buttonLognIn.Enabled = false;
                    buttonLognOut.Enabled = true;
                    break;
                case Camera.CameraStatue.OnReadPlay:
                    break;
                case Camera.CameraStatue.StopReadPlay:
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

            camera.checkSignParam();

            this.Close();
        }

        private void buttonLognIn_Click(object sender, EventArgs e)
        {
            camera.SignCamera();
        }

        private void buttonLognOut_Click(object sender, EventArgs e)
        {
            camera.SignOutCamera();
        }
    }
}

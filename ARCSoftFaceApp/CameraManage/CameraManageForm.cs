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
        }

        public CameraManageForm(Camera camera):
            this()
        {
            if (camera==null)
            {
                camera = new Camera();
            }
            this.camera = camera;
            if(camera.Statue==Camera.CameraStatue.SignOut)
            {

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

    }
}

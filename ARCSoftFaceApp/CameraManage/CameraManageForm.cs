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
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.camera.ip = this.textBoxIp.Text;
            this.camera.port = Int32.Parse(this.textBoxPort.Text);
            this.camera.user = this.textBoxUser.Text;
            this.camera.pwd = this.textBoxPwd.Text;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}

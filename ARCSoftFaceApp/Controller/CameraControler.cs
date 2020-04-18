using ARCSoftFaceApp.Entity;
using ARCSoftFaceApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARCSoftFaceApp.Controller
{
    /// <summary>
    /// 该类用于集中控制摄像头，并处理界面控件的刷新
    /// </summary>
    public class CameraControler
    {
        public List<CameraItem> cameras { get; set; }

        public CameraControler()
        {
            cameras = new List<CameraItem>();
        }

        /// <summary>
        /// 设备注册
        /// 当camera被实例化后，将该camera映射到cameras中，并对列表视图添加行的工作
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="parentView"></param>
        public void RegistrerCameraDevice(Camera camera, ListView parentView)
        {
            if(camera != null)
            {
                CameraItem cameraItem = new CameraItem();
                cameraItem.camera = camera;
                if(parentView!=null)
                {
                    ListViewItem viewItem = new ListViewItem("");
                    viewItem.SubItems.Add(camera.Ip);
                    viewItem.SubItems.Add(camera.CoverCameraStatue());
                    cameraItem.listViewItem = viewItem;
                    parentView.Items.Add(viewItem);

                    cameraItem.camera.ParamItemChangedEvent += cameraItem.RefreshViewItem;
                }

                cameras.Add(cameraItem);
                LoggerService.logger.Info($"摄像IP：{camera.Ip} 注册成功！");
            }
        }
    }

    public class CameraItem
    {
        public Camera camera { get; set; }
        public ListViewItem listViewItem { get; set; }

        public CameraItem()
        {
            camera = null;
            listViewItem = null;
        }
        public CameraItem(Camera camera, ListViewItem listViewItem)
        {
            this.camera = camera;
            this.listViewItem = listViewItem;
        }

        public void RefreshViewItem()
        {

            Action action = new Action(() =>
              {
                  if (listViewItem != null)
                      listViewItem.SubItems[2].Text = camera.CoverCameraStatue();
              });

            action.Invoke();
        }
    }
}

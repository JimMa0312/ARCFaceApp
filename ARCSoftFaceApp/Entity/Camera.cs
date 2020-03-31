using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCSoftFaceApp.Entity
{
    /// <summary>
    /// 摄像机
    /// </summary>
    public class Camera
    {
        public string ip { get; set; }
        public int port { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcSoftFace.Models
{
    /// <summary>
    /// 画面中3D人脸的旋转角度
    /// </summary>
    public struct ASF_Face3DAngle
    {
        public IntPtr roll;
        public IntPtr yaw;
        public IntPtr pitch;

        public IntPtr status;
        public int num;
    }
}

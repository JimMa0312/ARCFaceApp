using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcSoftFace.Entity
{
    public class ImageInfo
    {
        /// <summary>
        /// 图片的像素数据
        /// </summary>
        public IntPtr imgData { get; set; }
        /// <summary>
        /// 图片像素宽度
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 图片像素高度
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 图片像素格式
        /// </summary>
        public int format { get; set; }
    }
}

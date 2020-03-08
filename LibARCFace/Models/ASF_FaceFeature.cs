using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcSoftFace.Models
{
    /// <summary>
    /// 人脸特征结构体
    /// </summary>
    public struct ASF_FaceFeature
    {
        /// <summary>
        /// 特征值
        /// byte[]
        /// </summary>
        public IntPtr feature;
        /// <summary>
        /// 特征值长度
        /// </summary>
        public int featureSize;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcSoftFace
{
    /// <summary>
    /// 多人脸检测结构体
    /// </summary>
    public struct ASF_MultiFaceInfo
    {
        /// <summary>
        /// 人脸Rect集合
        /// </summary>
        public IntPtr faceRects;

        /// <summary>
        /// 人脸角度结果集， 与faceRects一一对应 对用OrientCode
        /// </summary>
        public IntPtr faceOrients;

        /// <summary>
        /// 结果集大小
        /// </summary>
        public int faceNum;

        /// <summary>
        /// faceID, IMAGE模式下返回FaceID
        /// </summary>
        public IntPtr faceID;
    }
}
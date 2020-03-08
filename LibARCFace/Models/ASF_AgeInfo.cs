using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcSoftFace.Models
{
    /// <summary>
    /// 年龄结果结构体
    /// </summary>
    public struct ASF_AgeInfo
    {
        /// <summary>
        /// 年龄检测结果集
        /// 0:未知； >0:年龄
        /// </summary>
        public IntPtr ageArray;
        /// <summary>
        /// 结果集大小
        /// </summary>
        public int num;
    }
}

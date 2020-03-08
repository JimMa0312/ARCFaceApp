using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcSoftFace.Models
{
    public struct ASF_GenderInfo
    {
        /// <summary>
        /// 性别检测结果集
        /// </summary>
        public IntPtr genderArray;
        public int num;
    }
}

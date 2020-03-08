using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArcSoftFace.Utils
{
    /// <summary>
    /// 将SDK的C++ dll封装成C#类
    /// </summary>
    public class ASFFunctions
    {
        /// <summary>
        /// SDK鼎泰链接库路径
        /// </summary>
        public const string Dll_PATH = "libarcsoft_face_engine.dll";

        /// <summary>
        /// 激活人脸识别SDK引擎函数
        /// </summary>
        /// <param name="appId">SDK对应的appID</param>
        /// <param name="sdkKey">SDK对应的SDKKey</param>
        /// <returns>调用结果</returns>
        [DllImport(Dll_PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ASFActivation(string appId, string sdkKey);
        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="detectMode"></param>
        /// <param name="detectFaceOrientPriority"></param>
        /// <param name="detectFaceScaleVal"></param>
        /// <param name="detectFaceMaxNum"></param>
        /// <param name="combinedMask"></param>
        /// <param name="pEngine"></param>
        /// <returns></returns>
        [DllImport(Dll_PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ASFInitEngine(uint detectMode, int detectFaceOrientPriority, int detectFaceScaleVal, int detectFaceMaxNum, int combinedMask, ref IntPtr pEngine);
    }
}

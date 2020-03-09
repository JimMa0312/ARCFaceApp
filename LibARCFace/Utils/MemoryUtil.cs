using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArcSoftFace.Utils
{
    /// <summary>
    /// 模拟C++下对内存的操作
    /// </summary>
    public class MemoryUtil
    {
        /// <summary>
        /// 申请内存
        /// </summary>
        /// <param name="len">长度（单位：字节byte）</param>
        /// <returns></returns>
        public static IntPtr Malloc(int len)
        {
            return Marshal.AllocHGlobal(len);
        }

        /// <summary>
        /// 释放掉托管的内存区域
        /// </summary>
        /// <param name="ptr">托管的指针</param>
        public static void Free(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        /// 将字节数组的内容深度拷贝到托管的内存中
        /// </summary>
        /// <param name="source">源字节数组</param>
        /// <param name="startIndex">元数据拷贝的起始位置</param>
        /// <param name="destination">托管的内存</param>
        /// <param name="length">要拷贝的长度</param>
        public static void Copy(byte[] source, int startIndex, IntPtr destination, int length)
        {
            Marshal.Copy(source, startIndex, destination, length);
        }

        /// <summary>
        /// 将托管的内存内容拷贝到字节数组中
        /// </summary>
        /// <param name="source">托管内存</param>
        /// <param name="destination">目标字节数组</param>
        /// <param name="startIndex">拷贝起始位置</param>
        /// <param name="length">拷贝长度</param>
        public static void Copy(IntPtr source, byte[] destination, int startIndex, int length)
        {
            Marshal.Copy(source, destination, startIndex, length);
        }

        /// <summary>
        /// 将托管的内存转换为选定的结构体对象
        /// </summary>
        /// <typeparam name="T">泛型 结构体</typeparam>
        /// <param name="ptr">托管指针</param>
        /// <returns></returns>
        public static T PtrToStructure<T>(IntPtr ptr)
        {
            return Marshal.PtrToStructure<T>(ptr);
        }

        /// <summary>
        /// 将结构体的内容复制到ptr托管的内存中
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="t">结构体</param>
        /// <param name="ptr">需要存放内瓤的指针</param>
        public static void StructureToPtr<T>(T t, IntPtr ptr)
        {
            Marshal.StructureToPtr<T>(t, ptr, false);
        }

        /// <summary>
        /// 获取类型的大小
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <returns>类型的大小</returns>
        public static int SizeOf<T>()
        {
            return Marshal.SizeOf<T>();
        }
    }
}

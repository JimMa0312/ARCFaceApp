using ArcSoftFace.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ArcSoftFace.Models;

namespace ArcSoftFace.Utils
{
    /// <summary>
    /// 使用虹软SDK进行人脸操作的细化逻辑
    /// </summary>
    public class FaceUtil
    {
        /// <summary>
        /// 人脸检测
        /// 检测RGB图像的人脸时，必须保证图像的宽度能被4整除，否则会失败
        /// </summary>
        /// <param name="pEngine">引擎</param>
        /// <param name="imageInfo">图像数据</param>
        /// <returns></returns>
        public static ASF_MultiFaceInfo DetectFace(IntPtr pEngine, ImageInfo imageInfo)
        {
            //创建多张人脸的数据结构体
            ASF_MultiFaceInfo multiFaceInfo = new ASF_MultiFaceInfo();

            //创建一个指针可以指向MultiFaceInfo结构
            IntPtr pMultiFaceInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_MultiFaceInfo>());
            int retCode = ASFFunctions.ASFDetectFaces(pEngine, imageInfo.width, imageInfo.height, imageInfo.format, imageInfo.imgData, pMultiFaceInfo);

            //当人脸识别错误，则释放内存，返回一个默认的结构
            if(retCode!=0)
            {
                MemoryUtil.Free(pMultiFaceInfo);
                return multiFaceInfo;
            }

            //将从C++程序集得到的多人脸结构内存转义成C#的多人脸结构体中
            multiFaceInfo = MemoryUtil.PtrToStructure<ASF_MultiFaceInfo>(pMultiFaceInfo);
            return multiFaceInfo;
        }

        /// <summary>
        /// 创建一个 锁 对象 用于对要接入多线程的逻辑块（指令块）进行锁存处理
        /// </summary>
        private static object locks = new object();
        /// <summary>
        /// 人脸检测
        /// </summary>
        /// <param name="pEngine">虹软引擎实例</param>
        /// <param name="image">图像 可以是window系统的图像对象</param>
        /// <returns></returns>
        public static ASF_MultiFaceInfo DetectFace(IntPtr pEngine, Image image)
        {
            lock(locks) //上锁
            {
                //创建多张人脸的数据结构体
                ASF_MultiFaceInfo multiFaceInfo = new ASF_MultiFaceInfo();
                if(image!=null)
                {
                    ImageInfo imageInfo = ImageUtil.ReadBMP(image);
                    if(imageInfo==null)
                    {
                        return multiFaceInfo;
                    }

                    multiFaceInfo = DetectFace(pEngine, imageInfo);
                    //释放掉图片信息，减少内存占用
                    MemoryUtil.Free(imageInfo.imgData);
                    return multiFaceInfo;
                }
                else
                {
                    return multiFaceInfo;
                }
            }
        }

        /// <summary>
        /// 从图像信息中提取人脸特征
        /// </summary>
        /// <param name="pEngine">虹软引擎句柄</param>
        /// <param name="imageInfo">图像信息</param>
        /// <param name="multiFaceInfo">人脸检测结果</param>
        /// <param name="singleFaceInfo">单个人脸的位置</param>
        /// <returns>保存人脸特征结构体指针</returns>
        public static IntPtr ExtractFeatrue(IntPtr pEngine, ImageInfo imageInfo, ASF_MultiFaceInfo multiFaceInfo, out ASF_SingleFaceInfo singleFaceInfo)
        {
            singleFaceInfo = new ASF_SingleFaceInfo();

            //如果没有检测到人脸
            if (multiFaceInfo.faceRects==null)
            {
                //创建一个空的特征结构体
                ASF_FaceFeature emptyFeature = new ASF_FaceFeature();
                IntPtr pEmptyFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
                MemoryUtil.StructureToPtr(emptyFeature, pEmptyFeature);

                return pEmptyFeature;
            }

            singleFaceInfo.faceRect = MemoryUtil.PtrToStructure<MRECT>(multiFaceInfo.faceRects);
            singleFaceInfo.faceOrient = MemoryUtil.PtrToStructure<int>(multiFaceInfo.faceOrients);
            IntPtr pSingleFaceInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_SingleFaceInfo>());
            MemoryUtil.StructureToPtr(singleFaceInfo, pSingleFaceInfo);

            //创建一个人脸特征结构体指针
            IntPtr pFaceFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
            //执行特征识别运算
            int retCode = ASFFunctions.ASFFaceFeatureExtract(pEngine, imageInfo.width, imageInfo.height, imageInfo.format, imageInfo.imgData, pSingleFaceInfo, pFaceFeature);
            Console.WriteLine("FR Extract Feature result: " + retCode);

            //当执行结果不是成功
            if (retCode !=0)
            {
                MemoryUtil.Free(pSingleFaceInfo);
                MemoryUtil.Free(pFaceFeature);

                ASF_FaceFeature emptyFeature = new ASF_FaceFeature();
                IntPtr pEmptyFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
                MemoryUtil.StructureToPtr(emptyFeature, pEmptyFeature);
                return pEmptyFeature;
            }

            #region 人脸特征深度复制
            ASF_FaceFeature faceFeature = MemoryUtil.PtrToStructure<ASF_FaceFeature>((pFaceFeature));
            byte[] feature = new byte[faceFeature.featureSize];
            //将特征值提取出来(类型转换成C#的类型
            MemoryUtil.Copy(faceFeature.feature, feature, 0, faceFeature.featureSize);


            ASF_FaceFeature localFeature = new ASF_FaceFeature();
            localFeature.feature = MemoryUtil.Malloc(feature.Length);
            MemoryUtil.Copy(feature, 0, localFeature.feature, feature.Length);
            localFeature.featureSize = feature.Length;
            IntPtr pLocalFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
            MemoryUtil.StructureToPtr(localFeature, pLocalFeature);

            MemoryUtil.Free(pSingleFaceInfo);
            MemoryUtil.Free(pFaceFeature);
            #endregion

            return pLocalFeature;
        }

        /// <summary>
        /// 提取人脸特征
        /// </summary>
        /// <param name="pEngine"></param>
        /// <param name="image"></param>
        /// <param name="singleFaceInfo"></param>
        /// <returns></returns>
        public static IntPtr ExtractFeatrue(IntPtr pEngine, Image image, out ASF_SingleFaceInfo singleFaceInfo)
        {
            if (image == null)
            {
                return ReturnEmptyStruct(out singleFaceInfo);
            }

            if (image.Width>1536 || image.Height>1536)
            {
                image = ImageUtil.ScaleImage(image, 1536, 1536);
            }
            else
            {
                image = ImageUtil.ScaleImage(image, image.Width, image.Height);
            }

            ImageInfo imageInfo = ImageUtil.ReadBMP(image);

            if (imageInfo==null)
            {
                return ReturnEmptyStruct(out singleFaceInfo);
            }

            //进行人脸检测
            ASF_MultiFaceInfo multiFaceInfo = DetectFace(pEngine, imageInfo);
            singleFaceInfo = new ASF_SingleFaceInfo();
            IntPtr pFaceModel = ExtractFeatrue(pEngine, imageInfo, multiFaceInfo, out singleFaceInfo);
            MemoryUtil.Free(imageInfo.imgData);
            return pFaceModel;
        }

        /// <summary>
        /// 提取单人脸特征
        /// </summary>
        /// <param name="pEngine"></param>
        /// <param name="image"></param>
        /// <param name="singleFaceInfo"></param>
        /// <returns></returns>
        public static IntPtr ExtractFeature(IntPtr pEngine, Image image, ASF_SingleFaceInfo singleFaceInfo)
        {
            ImageInfo imageInfo = ImageUtil.ReadBMP(image);
            if (imageInfo == null)
            {
                return ReturnEmptyFeature();
            }

            IntPtr pSingleFaceInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_SingleFaceInfo>());
            MemoryUtil.StructureToPtr(singleFaceInfo, pSingleFaceInfo);

            IntPtr pFaceFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
            int retCode = -1;

            try
            {
                retCode = ASFFunctions.ASFFaceFeatureExtract(pEngine, imageInfo.width, imageInfo.height, imageInfo.format, imageInfo.imgData, pSingleFaceInfo, pFaceFeature);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (retCode!=0)
            {
                MemoryUtil.Free(pSingleFaceInfo);
                MemoryUtil.Free(pFaceFeature);
                MemoryUtil.Free(imageInfo.imgData);

                return ReturnEmptyFeature();
            }

            //人脸特征feature过滤
            ASF_FaceFeature faceFeature = MemoryUtil.PtrToStructure<ASF_FaceFeature>(pFaceFeature);
            byte[] feature = new byte[faceFeature.featureSize];
            MemoryUtil.Copy(faceFeature.feature, feature, 0, faceFeature.featureSize);

            ASF_FaceFeature localFeature = new ASF_FaceFeature();
            localFeature.feature = MemoryUtil.Malloc(feature.Length);
            MemoryUtil.Copy(feature, 0, localFeature.feature, feature.Length);
            localFeature.featureSize = feature.Length;
            IntPtr pLocalFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
            MemoryUtil.StructureToPtr(localFeature, pLocalFeature);

            //释放指针
            MemoryUtil.Free(pSingleFaceInfo);
            MemoryUtil.Free(pFaceFeature);
            MemoryUtil.Free(imageInfo.imgData);

            return pLocalFeature;
        }

        private static IntPtr ReturnEmptyFeature()
        {
            ASF_FaceFeature emptyFeature = new ASF_FaceFeature();

            IntPtr pEmptyFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
            MemoryUtil.StructureToPtr(emptyFeature, pEmptyFeature);

            return pEmptyFeature;
        }

        private static IntPtr ReturnEmptyStruct(out ASF_SingleFaceInfo singleFaceInfo)
        {
            singleFaceInfo = new ASF_SingleFaceInfo();
            ASF_FaceFeature emptyFeatrue = new ASF_FaceFeature();
            IntPtr pEmptyFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
            MemoryUtil.StructureToPtr(emptyFeatrue, pEmptyFeature);

            return pEmptyFeature;
        }


        /// <summary>
        /// 获取多个人脸检测结果中面积最大的人脸
        /// </summary>
        /// <param name="multiFaceInfo">人脸检测结果</param>
        /// <returns>面积最大的人脸信息</returns>
        public static ASF_SingleFaceInfo GetMaxFace(ASF_MultiFaceInfo multiFaceInfo)
        {
            ASF_SingleFaceInfo singleFaceInfo = new ASF_SingleFaceInfo();
            singleFaceInfo.faceRect = new MRECT();
            singleFaceInfo.faceOrient = 1;

            int maxArea = 0;
            int index = -1;
            for (int i = 0; i < multiFaceInfo.faceNum; i++)
            {
                try
                {
                    MRECT rect = MemoryUtil.PtrToStructure<MRECT>(multiFaceInfo.faceRects + MemoryUtil.SizeOf<MRECT>() * i);
                    int area = (rect.right - rect.left) * (rect.bottom - rect.top);
                    if (maxArea <= area)
                    {
                        maxArea = area;
                        index = i;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (index != -1)
            {
                singleFaceInfo.faceRect = MemoryUtil.PtrToStructure<MRECT>(multiFaceInfo.faceRects + MemoryUtil.SizeOf<MRECT>() * index);
                singleFaceInfo.faceOrient = MemoryUtil.PtrToStructure<int>(multiFaceInfo.faceOrients + MemoryUtil.SizeOf<int>() * index);
            }
            return singleFaceInfo;
        }
    }

}

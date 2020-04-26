using ArcSoftFace.Models;
using ArcSoftFace.Utils;
using ARCSoftFaceApp.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCSoftFaceApp.Entity
{
    public class FaceVideoRecognizer : IFaceRecognizer
    {

        /// <summary>
        /// 视频人脸识别引擎句柄
        /// </summary>
        private IntPtr pVideoEngine = IntPtr.Zero;

        /// <summary>
        /// 视频用来提取人脸特征和人脸比对的引擎句柄
        /// </summary>
        private IntPtr pVideoRGBImageEngine = IntPtr.Zero;

        public void initFaceEngine()
        {
            //初始化视频模式下人脸检测引擎
            uint detectModeVideo = DetectionMode.ASF_DETECT_MODE_VIDEO;
            int combinedMaskVideo = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION;

            //Video模式下检测脸部的角度优先值
            int videoDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_0_HIGHER_EXT;

            //人脸在图片中所占比例，如果需要调整检测人脸尺寸请修改此值，有效数值为2-32
            int detectFaceScaleVal = 16;
            //最大需要检测的人脸个数
            int detectFaceMaxNum = 5;

            int retCode = ASFFunctions.ASFInitEngine(detectModeVideo, videoDetectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMaskVideo, ref pVideoEngine);


            LoggerService.logger.Info($"初始化视频用人脸识别引擎结果：{retCode}");


            //初始化 用于采集人脸特征的引擎
            uint detectMode = DetectionMode.ASF_DETECT_MODE_IMAGE;
            //Image模式下检测脸部的角度优先值
            int imageDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_0_ONLY;
            //最大需要检测的人脸个数
            detectFaceMaxNum = 1;

            //引擎初始化时需要初始化的检测功能组合
            int combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_AGE | FaceEngineMask.ASF_GENDER | FaceEngineMask.ASF_FACE3DANGLE;
            retCode = ASFFunctions.ASFInitEngine(detectMode, imageDetectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pVideoRGBImageEngine);

            LoggerService.logger.Info($"初始化视频用人脸识别引擎结果：{retCode}");
        }

        public int ScanFaceFeature(Bitmap bitmap, ref List<FaceInfo> singleFaceInfos)
        {
            int num = 0;

            if(singleFaceInfos==null)
            {
                return 0;
            }

            foreach (var singleFaceInfo in singleFaceInfos)
            {
                //如果没有人脸比对成功过
                if (singleFaceInfo.isFacePass==false)
                {
                    singleFaceInfo.faceFeature = FaceUtil.ExtractFeature(pVideoRGBImageEngine, bitmap, singleFaceInfo.singleFaceInfo);

                    num++;
                }
            }
            return num;
        }

        public List<FaceInfo> ScanFaces(Bitmap bitmap)
        {
            List <FaceInfo> singleFaces = new List<FaceInfo>();

            if(bitmap==null)
            {
                return null;
            }

            //从视频帧中获取 多个人脸的矩形框位置
            ASF_MultiFaceInfo multiFaceInfo = FaceUtil.DetectFace(pVideoEngine, bitmap);

            //int[] faceIds=null;
            //if (multiFaceInfo.faceNum>0)
            //{
            //    faceIds = MemoryUtil.PtrToStructure<int[]>(multiFaceInfo.faceID);
            //}

            //将MultiFaceInfo结构体中的数据提取成单人脸数据并放入结构体中
            for (int i = 0; i < multiFaceInfo.faceNum; i++)
            {
                FaceInfo faceInfo = new FaceInfo();

                //faceInfo.faceId = faceIds[i];

                faceInfo.singleFaceInfo.faceRect = MemoryUtil.PtrToStructure<MRECT>(multiFaceInfo.faceRects + MemoryUtil.SizeOf<MRECT>() * i);
                faceInfo.singleFaceInfo.faceOrient = MemoryUtil.PtrToStructure<int>(multiFaceInfo.faceOrients + MemoryUtil.SizeOf<int>() * i);

                singleFaces.Add(faceInfo);
            }

            return singleFaces;
        }
    }

    /// <summary>
    /// 针对图片进行的人脸识别处理模块
    /// </summary>
    public class FaceImageRecognizer : IFaceRecognizer
    {
        /// <summary>
        /// 引擎Handle
        /// </summary>
        private IntPtr pImageEngine = IntPtr.Zero;

        public void initFaceEngine()
        {
            //初始化引擎
            uint detectMode = DetectionMode.ASF_DETECT_MODE_IMAGE;
            //Image模式下检测脸部的角度优先值
            int imageDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_0_ONLY;
            //人脸在图片中所占比例，如果需要调整检测人脸尺寸请修改此值，有效数值为2-32
            int detectFaceScaleVal = 16;
            //最大需要检测的人脸个数
            int detectFaceMaxNum = 5;
            //引擎初始化时需要初始化的检测功能组合
            int combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_AGE | FaceEngineMask.ASF_GENDER | FaceEngineMask.ASF_FACE3DANGLE;
            //初始化引擎，正常值为0，其他返回值请参考http://ai.arcsoft.com.cn/bbs/forum.php?mod=viewthread&tid=19&_dsign=dbad527e
            int result = ASFFunctions.ASFInitEngine(detectMode, imageDetectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pImageEngine);

            LoggerService.logger.Info($"初始化图片采集用人脸识别引擎结果：{result}");
        }

        public int ScanFaceFeature(Bitmap bitmap, ref List<FaceInfo> singleFaceInfos)
        {
            int num = 0;
            foreach (var singleFaceInfo in singleFaceInfos)
            {
                    singleFaceInfo.faceFeature = FaceUtil.ExtractFeature(pImageEngine, bitmap, singleFaceInfo.singleFaceInfo);

                    num++;
            }
            return num;
        }

        public List<FaceInfo> ScanFaces(Bitmap bitmap)
        {
            List<FaceInfo> singleFaces = new List<FaceInfo>();

            if (bitmap == null)
            {
                return null;
            }

            //从视频帧中获取 多个人脸的矩形框位置
            ASF_MultiFaceInfo multiFaceInfo = FaceUtil.DetectFace(pImageEngine, bitmap);

            //如果识别出人脸，且当前只有一个人脸
            if(multiFaceInfo.faceNum==1)
            {
                //将MultiFaceInfo结构体中的数据提取成单人脸数据并放入结构体中
                for (int i = 0; i < multiFaceInfo.faceNum; i++)
                {

                    FaceInfo faceInfo = new FaceInfo();

                    faceInfo.singleFaceInfo.faceRect = MemoryUtil.PtrToStructure<MRECT>(multiFaceInfo.faceRects + MemoryUtil.SizeOf<MRECT>() * i);
                    faceInfo.singleFaceInfo.faceOrient = MemoryUtil.PtrToStructure<int>(multiFaceInfo.faceOrients + MemoryUtil.SizeOf<int>() * i);

                    singleFaces.Add(faceInfo);
                }
            }
            else
            {
                LoggerService.logger.Info($"当前图片中含有多个人脸或没有人脸，请重新选择单人图片，进行特征提取");
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }

            return singleFaces;
        }
    }

    public class FaceInfo:IDisposable
    {
        public int faceId;
        public ASF_SingleFaceInfo singleFaceInfo;
        public IntPtr faceFeature;
        /// <summary>
        /// 是否已经进行了人脸识别
        /// </summary>
        public Boolean isFacePass;

        public FaceInfo()
        {
            faceId = 0;
            singleFaceInfo = new ASF_SingleFaceInfo();
            faceFeature = IntPtr.Zero;
            isFacePass = false;
        }

        /// <summary>
        /// 用来手动（显示）释放资源
        /// </summary>
        public void Dispose()
        {
            
            if (faceFeature!=IntPtr.Zero)
            {
                MemoryUtil.Free(faceFeature);
                faceFeature = IntPtr.Zero;
            }
        }
    }


    /// <summary>
    /// 人脸识别引擎器
    /// </summary>
    public interface IFaceRecognizer
    {
        /// <summary>
        /// 初始化用来人脸识别的引擎
        /// </summary>
        void initFaceEngine();

        /// <summary>
        /// 扫描人脸
        /// </summary>
        List<FaceInfo> ScanFaces(Bitmap bitmap);
        /// <summary>
        /// 根据扫描出的人脸数据，提取人脸的特征量
        /// </summary>
        /// <param name="singleFaceInfos"></param>
        /// <returns></returns>
        int ScanFaceFeature(Bitmap bitmap, ref List<FaceInfo> singleFaceInfos);
    }
}

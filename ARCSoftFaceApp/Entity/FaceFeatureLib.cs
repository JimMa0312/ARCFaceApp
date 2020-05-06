using ArcSoftFace.Models;
using ArcSoftFace.Utils;
using ARCSoftFaceApp.EntityFrameDataModel;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCSoftFaceApp.Entity
{
    public class FaceFeatureLib
    {
        public static List<StudentFaceFeature> faceFeatures = new List<StudentFaceFeature>();

        /// <summary>
        /// 从数据库中重新加载人脸图像特征库
        /// </summary>
        public static void LoadFaceLibrary()
        {
            ClearFaceLibrary();

            using (var db=new attendance_sysEntities())
            {
                var tFaces = db.t_face;
                foreach (var face in tFaces)
                {
                    StudentFaceFeature tempFeature = new StudentFaceFeature(face);
                    faceFeatures.Add(tempFeature);
                }
            }
        }
        /// <summary>
        /// 清除所有老的数据
        /// </summary>
        public static void ClearFaceLibrary()
        {
            if (faceFeatures.Count > 0)
            {
                foreach (var item in faceFeatures)
                {
                    item.Dispose();
                }

                faceFeatures.Clear();
            }
        }
    }

    public class StudentFaceFeature:IDisposable
    {
        public string studentId;
        public ASF_FaceFeature faceFeature;
        public IntPtr pFaceFeature;
        public StudentFaceFeature(t_face dbFace)
        {
            studentId = dbFace.studnet_id;
            faceFeature = new ASF_FaceFeature();
            faceFeature.featureSize = (int)dbFace.face_feature_length;
            if(faceFeature.featureSize==dbFace.face_feature.Length)
            {
                faceFeature.feature = MemoryUtil.Malloc(faceFeature.featureSize);
                MemoryUtil.Copy(dbFace.face_feature, 0, faceFeature.feature, faceFeature.featureSize);
                pFaceFeature = MemoryUtil.Malloc(MemoryUtil.SizeOf<ASF_FaceFeature>());
                MemoryUtil.StructureToPtr<ASF_FaceFeature>(faceFeature, pFaceFeature);
            }
            else
            {
                pFaceFeature = IntPtr.Zero;
                faceFeature.feature = IntPtr.Zero;
                faceFeature.featureSize = 0;
            }
            
        }

        public void Dispose()
        {
            if(pFaceFeature!=IntPtr.Zero)
            {
                MemoryUtil.Free(pFaceFeature);
            }
            if(faceFeature.feature!=IntPtr.Zero)
            {
                MemoryUtil.Free(faceFeature.feature);
            }

            faceFeature.featureSize = 0;
            studentId = null;
        }
    }
}

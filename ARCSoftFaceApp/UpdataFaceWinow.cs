using ArcSoftFace.Models;
using ArcSoftFace.Utils;
using ARCSoftFaceApp.Entity;
using ARCSoftFaceApp.EntityFrameDataModel;
using ARCSoftFaceApp.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARCSoftFaceApp
{
    public partial class UpdataFaceWinow : Form
    {
        private Queue<t_face> t_Faces;
        private FaceImageRecognizer faceImageRecognizer;
        private readonly long maxSize=1024*1024*2;//2Mb
        public UpdataFaceWinow()
        {
            InitializeComponent();
            t_Faces = new Queue<t_face>();
            faceImageRecognizer = new FaceImageRecognizer();
            faceImageRecognizer.initFaceEngine();
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择图片";
            openFileDialog.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";
            openFileDialog.Multiselect = true;
            openFileDialog.FileName = string.Empty;
            ImageListView.Refresh();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;

                for (int i = 0; i < fileNames.Length; i++)
                {
                    if(checkImage(fileNames[i]))
                    {

                        t_face temp_face = new t_face();
                        temp_face.image_path = fileNames[i];
                        FileInfo fileInfo = new FileInfo(fileNames[i]);
                        temp_face.studnet_id = fileInfo.Name.Split('.')[0];

                        if(getFaceFeature(ref temp_face))
                        {
                            t_Faces.Enqueue(temp_face);
                        }
                        else
                        {
                            LoggerService.logger.Error($"学生{fileNames}的人脸无法提取特征!");
                        }
                    }
                }
            }

            if(t_Faces.Count>0)
            {
                buttonUpdateFace.Enabled = true;
            }
        }

        private bool getFaceFeature(ref t_face t_Face)
        {
            Image image = ImageUtil.readFromFile(t_Face.image_path);
            bool result = false;

            //压缩图片的长宽为临界大小1536
            if (image.Width > 1536 || image.Height > 1536)
            {
                image = ImageUtil.ScaleImage(image, 1536, 1536);
            }

            //裁剪，因为虹软要求图片宽度要是4的整数倍，所以要检测一下，如果不是就把宽缩小为4的倍数
            if (image.Width % 4 != 0)
            {
                image = ImageUtil.ScaleImage(image, image.Width - (image.Width % 4), image.Height);
            }

            //把image对象转化为位图的对象
            Bitmap bitmap = new Bitmap(image);

            //使用人脸检测引擎去检测人脸，返回的lis列表里存了人脸的位置
            List<FaceInfo> faceInfos = faceImageRecognizer.ScanFaces(bitmap);

            //判断一张照片是否就一个人脸
            if (faceInfos.Count == 1)
            {
                //把第一个人脸的信息传入人脸识别引擎中，提取出特征的结构体指引到faceinfo中，返回是否成功
                int num = faceImageRecognizer.ScanFaceFeature(bitmap, faceInfos[0]); 

                if (num == 0)
                {
                    ASF_SingleFaceInfo singleFaceInfo = faceInfos[0].singleFaceInfo;
                    //t_face就是实体类映射对象
                    t_Face.face_feature_length = faceInfos[0].faceFeature.featureSize;
                    t_Face.face_feature = new byte[(int)t_Face.face_feature_length];

                    //把结构体里的特征纯copy到t_face中
                    MemoryUtil.Copy(faceInfos[0].faceFeature.feature, t_Face.face_feature, 0, faceInfos[0].faceFeature.featureSize);
                    result = true;
                    LoggerService.logger.Info(string.Format("已提取人脸特征值，[left:{0},right:{1},top:{2},bottom:{3},orient:{4}]", singleFaceInfo.faceRect.left, singleFaceInfo.faceRect.right, singleFaceInfo.faceRect.top, singleFaceInfo.faceRect.bottom, singleFaceInfo.faceOrient));
                    string tempImagePath = t_Face.image_path;
                    string id = t_Face.studnet_id;

                    //裁剪出头像，依次展示在界面，多线程操作，解决可能异常越界问题
                    Invoke(new Action(()=> {
                        image = ImageUtil.CutImage(image, singleFaceInfo.faceRect.left, singleFaceInfo.faceRect.top, singleFaceInfo.faceRect.right, singleFaceInfo.faceRect.bottom);
                        imageLists.Images.Add(tempImagePath, image);
                        ImageListView.Items.Add(id, tempImagePath);

                        listViewFaceDetal.Items.Add(new ListViewItem(new string[]{ "等待", id, "" }));
                        listViewFaceDetal.Refresh();
                        ImageListView.Refresh();
                    }));
                }
                else
                {
                    LoggerService.logger.Error("提取人脸特征失败！");
                }
                faceInfos[0].Dispose();
                faceInfos[0] = null;
                faceInfos.Clear();
            }

            image.Dispose();
            bitmap.Dispose();

            return result;
        }

        private bool checkImage(string imagePath)
        {
            if (imagePath == null)
            {
                LoggerService.logger.Error("图片不存在，请确认后再导入\r\n");
                return false;
            }
            try
            {
                //判断图片是否正常，如将其他文件把后缀改为.jpg，这样就会报错
                Image image = ImageUtil.readFromFile(imagePath);
                if (image == null)
                {
                    throw new Exception();
                }
                else
                {
                    image.Dispose();
                }
            }
            catch
            {
                LoggerService.logger.Error(string.Format("{0} 图片格式有问题，请确认后再导入\r\n", imagePath));
                return false;
            }
            FileInfo fileCheck = new FileInfo(imagePath);
            if (fileCheck.Exists == false)
            {
                LoggerService.logger.Error(string.Format("{0} 不存在\r\n", fileCheck.Name));
                return false;
            }
            else if (fileCheck.Length > maxSize)
            {
                LoggerService.logger.Error(string.Format("{0} 图片大小超过2M，请压缩后再导入\r\n", fileCheck.Name));
                return false;
            }
            else if (fileCheck.Length < 2)
            {
                LoggerService.logger.Error(string.Format("{0} 图像质量太小，请重新选择\r\n", fileCheck.Name));
                return false;
            }
            return true;
        }

        private void UpdataFaceWinow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(faceImageRecognizer!=null)
            {
                faceImageRecognizer.Dispose();
            }
        }

        private async void buttonUpdateFace_Click(object sender, EventArgs e)
        {
            if(t_Faces?.Count>0)
            {
                await UpdateFace();
            }
        }

        private async Task UpdateFace()
        {
            using (var db = new attendance_sysEntities())
            {
                int i = 0;
                while(t_Faces.Count>0)
                {
                    t_face tempFace = t_Faces.Dequeue();
                    //从数据库中查询是否有该stduentid的特征记录
                    var sqface = db.t_face.Where(face => face.studnet_id == tempFace.studnet_id).FirstOrDefault();
                    int records = 0;
                    //如果数据库中有该同学的人脸特征记录
                    if (sqface != null)
                    {
                        //直接更新该记录
                        sqface.face_feature = tempFace.face_feature;
                        sqface.face_feature_length = tempFace.face_feature_length;
                        sqface.image_path = "";
                    }
                    else
                    {
                        tempFace.image_path = "";
                        //如果没有记录，则插入一条
                        db.t_face.Add(tempFace);

                    }
                    records = await db.SaveChangesAsync();

                    Invoke(new Action(() =>
                    {
                        if (records > 0)
                        {
                            listViewFaceDetal.Items[i].SubItems[0].Text= "正确";
                            listViewFaceDetal.Items[i].SubItems[0].ForeColor = Color.Green;
                            listViewFaceDetal.Items[i].SubItems[2].Text = "更新完成";
                        }
                        else
                        {
                            listViewFaceDetal.Items[i].SubItems[0].Text = "错误";
                            listViewFaceDetal.Items[i].SubItems[0].ForeColor = Color.Red;
                            listViewFaceDetal.Items[i].SubItems[2].Text = "无法对数据库做修改操作";
                        }

                        listViewFaceDetal.Refresh();
                    }));

                    i++;

                }
            }
        }
    }
}

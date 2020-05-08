using ArcSoftFace.Entity;
using ArcSoftFace.Models;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace ArcSoftFace.Utils
{
    /// <summary>
    /// 图片处理工具类
    /// </summary>
    public class ImageUtil
    {
        /// <summary>
        /// 从本地文件中获取图像流
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public static Image readFromFile(string imageUrl)
        {
            Image img = null;
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(imageUrl, FileMode.Open, FileAccess.Read);
                img = Image.FromStream(fileStream);
            }
            finally
            {
                fileStream.Close();
            }

            return img;
        }

        /// <summary>
        /// 获取图片信息
        /// </summary>
        /// <param name="imageUrl">图片文件地址</param>
        /// <returns>成功返回一个ImageInfo结构， 失败返回null</returns>
        public static ImageInfo ReadBMP(Image image)
        {
            //创建一个ASF的图像信息结构
            ImageInfo imageInfo = new ImageInfo();
            //创建一个Emgu的图像结构，用于将位图像流进行传唤，传唤为RBG格式的byte数组
            Image<Bgr, byte> my_Image = null;
            //创建一个位图像对象
            Bitmap bitmap = null;
            try
            {
                //根据Image流实例化位图像对象
                bitmap = new Bitmap(image);
                if (bitmap == null)
                {
                    return null;
                }
                //根据位图对象创建 Emgu对象，利用Opencv接口进行格式转换 
                my_Image = new Image<Bgr, byte>(bitmap);
                //图像的byte数组格式为[Bule0, Green0, Red0,...,Bule(n-1), Green(n-1), Red(n-1)] 
                imageInfo.format = ASF_ImagePixelFormat.ASVL_PAF_RGB24_B8G8R8;
                imageInfo.width = my_Image.Width;
                imageInfo.height = my_Image.Height;

                imageInfo.imgData = MemoryUtil.Malloc(my_Image.Bytes.Length);
                MemoryUtil.Copy(my_Image.Bytes, 0, imageInfo.imgData, my_Image.Bytes.Length);


                return imageInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (my_Image != null)
                {
                    my_Image.Dispose();
                    my_Image = null;
                }
                if (bitmap != null)
                {
                    bitmap.Dispose();
                    bitmap = null;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取图片IR信息
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        //public static ImageInfo ReadBMP_IR(Bitmap bitmap)
        //{
        //    ImageInfo imageInfo = new ImageInfo();
        //    Image<Bgr, byte> my_Image = null;
        //    Image<Gray, byte> gray_image = null;

        //    try
        //    {
        //        //根据位图对象创建 Emgu对象，利用Opencv接口进行格式转换 
        //        my_Image = new Image<Bgr, byte>(bitmap);
        //        //将RGB图像转换为灰度图像
        //        gray_image = my_Image.Convert<Gray, byte>();
        //        imageInfo.format = ASF_ImagePixelFormat.ASVL_PAF_GARY;
        //        imageInfo.width = gray_image.Width;
        //        imageInfo.height = gray_image.Height;
        //        imageInfo.imgData = MemoryUtil.Malloc(gray_image.Bytes.Length);
        //        MemoryUtil.Copy(gray_image.Bytes, 0, imageInfo.imgData, gray_image.Bytes.Length);

        //        return imageInfo;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        if (my_Image != null)
        //        {
        //            my_Image.Dispose();
        //        }
        //        if (gray_image != null)
        //        {
        //            gray_image.Dispose();
        //        }
        //    }

        //    return null;
        //}

        /// <summary>
        /// 用矩形框标记图片指定区域
        /// </summary>
        /// <param name="image">图片</param>
        /// <param name="startX">矩形框左上角X坐标</param>
        /// <param name="startY">矩形框左上角Y坐标</param>
        /// <param name="width">矩形框宽</param>
        /// <param name="height">矩形框高</param>
        /// <returns></returns>
        public static Image MarkRect(Image image, int startX, int startY, int width, int height)
        {
            //复制一份图像
            Image clone = (Image)image.Clone();

            //将图像映射在绘制版面上
            Graphics g = Graphics.FromImage(clone);

            try
            {
                //创建刷子
                Brush brush = new SolidBrush(Color.Red);

                //创建一个宽为2的笔
                Pen pen = new Pen(brush, 2);
                //设置绘制直线
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                //绘制方框
                g.DrawRectangle(pen, new Rectangle(startX, startY, width, height));

                return clone;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (g != null)
                {
                    g.Dispose();
                }
            }

            return null;
        }

        /// <summary>
        /// 用矩形框标记图片指定读取，添加年龄和性别标注
        /// </summary>
        /// <param name="image"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="width"></param>
        /// <param name="heigh"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="showWidth"></param>
        /// <returns></returns>
        public static Image MarkRectAndString(Image image, int startX, int startY, int width, int heigh, int age, int gender, int showWidth)
        {
            Image clone = (Image)image.Clone();
            Graphics g = Graphics.FromImage(clone);
            try
            {
                Brush brush = new SolidBrush(Color.Red);
                int penWidth = image.Width / showWidth;
                Pen pen = new Pen(brush, penWidth > 1 ? 2 * penWidth : 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(pen, new Rectangle(startX < 1 ? 0 : startX, startY < 1 ? 0 : startY, width, heigh));
                StringBuilder genderStr = new StringBuilder();
                switch (gender)
                {
                    case 0:
                        genderStr.Append("男");
                        break;
                    case 1:
                        genderStr.Append("女");
                        break;
                    default:
                        break;
                }
                int fontSize = image.Width / showWidth;
                if (fontSize > 1)
                {
                    int temp = 12;
                    for (int i = 0; i < fontSize; i++)
                    {
                        temp += 6;
                    }
                    fontSize = temp;
                }
                else if (fontSize == 1)
                {
                    fontSize = 14;
                }
                else
                {
                    fontSize = 12;
                }

                g.DrawString($"年龄:{age}, 性别:{genderStr.ToString()}", new Font(FontFamily.GenericSansSerif, fontSize), brush, startX < 1 ? 0 : startX, (startY - 20) < 1 ? 0 : startY - 20);

                return clone;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                g.Dispose();
            }

            return null;
        }

        /// <summary>
        /// 按指定宽高缩放图片
        /// </summary>
        /// <param name="image"></param>
        /// <param name="dstWidth"></param>
        /// <param name="dstHeight"></param>
        /// <returns></returns>
        public static Image ScaleImage(Image image, int dstWidth, int dstHeight)
        {
            Graphics g = null;

            try
            {
                float scaleRate = getWidthAndHeight(image.Width, image.Height, dstWidth, dstHeight);
                int width = (int)(image.Width * scaleRate);
                int heigh = (int)(image.Height * scaleRate);

                //根据虹软SDK的协议规定 图片宽度必须是4的倍数
                if (width%4!=0)
                {
                    width = width - width % 4;
                }

                Bitmap desBitmap = new Bitmap(width, heigh);
                g = Graphics.FromImage(desBitmap);
                //清楚绘图设置的背景色
                g.Clear(Color.Transparent);

                //选择高质量绘制操作
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //选择高质量的图像呈现效果
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //执行高质量图像变换
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, new Rectangle(0, 0, width, heigh), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

                return desBitmap;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(image != null)
                {
                    image.Dispose();
                }
                if (g != null)
                {
                    g.Dispose();
                }
            }

            return null;
        }

        /// <summary>
        /// 获取图片缩放比例
        /// </summary>
        /// <param name="oldWidth"></param>
        /// <param name="oldHeight"></param>
        /// <param name="newWidth"></param>
        /// <param name="newHeight"></param>
        /// <returns></returns>
        public static float getWidthAndHeight(int oldWidth, int oldHeight, int newWidth, int newHeight)
        {
            float scaleRate = 0.0f;

            //如果要缩小图片
            if (oldWidth>=newWidth && oldHeight>=newHeight)
            {
                int widthDis = oldWidth - newWidth;
                int heighDis = oldHeight - newHeight;

                //如果宽的变化比高的变化大
                if (widthDis>heighDis)
                {
                    scaleRate = newWidth * 1f / oldWidth;
                }
                else
                {
                    scaleRate = newHeight * 1f / oldWidth;
                }
            }
            else if (oldWidth>=newWidth && oldHeight<newHeight)
            {
                scaleRate = newWidth * 1f / oldWidth;
            }
            else if (oldWidth<newWidth && oldHeight>=newHeight)
            {
                scaleRate = newHeight * 1f / oldHeight;
            }
            else
            {
                int widthDis = newWidth - oldWidth;
                int heighDis = newHeight - oldHeight;

                //如果宽的变化比高的变化大
                if (widthDis > heighDis)
                {
                    scaleRate = newWidth * 1f / oldWidth;
                }
                else
                {
                    scaleRate = newHeight * 1f / oldWidth;
                }
            }

            return scaleRate;
        }
        /// <summary>
        /// 裁剪图片
        /// </summary>
        /// <param name="src"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        /// <returns></returns>
        public static Image CutImage(Image src, int left, int top, int right, int bottom)
        {
            try
            {
                Bitmap srcBitmap = new Bitmap(src);

                int width = right - left;
                int heigh = bottom - top;

                Bitmap desBitmap = new Bitmap(width, heigh);

                using (Graphics g = Graphics.FromImage(desBitmap))
                {
                    g.Clear(Color.Transparent);

                    //选择高质量绘制操作
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    //选择高质量的图像呈现效果
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //执行高质量图像变换
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(srcBitmap, new Rectangle(0, 0, width, heigh), left, top, width, heigh, GraphicsUnit.Pixel);
                }

                return desBitmap;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
}

using ArcSoftFace.Utils;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ARCSoftFaceApp.Util
{
    public class ImageCover
    {
        public Image<Bgr, Byte> image;
        public byte[] yuvs;

        public ImageCover()
        {
            image = null;
            yuvs = null;
        }

        public Bitmap Yv12_2_BGR(ref IntPtr pBuf, int nSize, int height, int width)
        {
            Bitmap tempBitMap = null;

            if(yuvs==null)
            {
                yuvs = new byte[nSize];
            }
            if(image==null)
            {
                image = new Image<Bgr, byte>(width, height);
            }

            MemoryUtil.Copy(pBuf, yuvs, 0, nSize);

            GCHandle handle = GCHandle.Alloc(yuvs, GCHandleType.Pinned);

            using (Image<Bgr, Byte> yv12p=new Image<Bgr, byte>(width,(height>>1)*3, width, handle.AddrOfPinnedObject()))
            {
                CvInvoke.CvtColor(yv12p, image, Emgu.CV.CvEnum.ColorConversion.Yuv2BgrYv12);

                tempBitMap = yv12p.ToBitmap();
            }

            if(handle.IsAllocated)
            {
                handle.Free();
            }

            return tempBitMap;
        }
    }
}

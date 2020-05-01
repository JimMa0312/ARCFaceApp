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
        public Image<Bgr,byte> Yv12_2_BGR(ref IntPtr pBuf, int nSize, int height, int width)
        {

            if (yuvs == null)
            {
                yuvs = new byte[nSize];
            }
            if (image == null)
            {
                image = new Image<Bgr, byte>(width, height);
            }

            MemoryUtil.Copy(pBuf, yuvs, 0, nSize);

            GCHandle handle = GCHandle.Alloc(yuvs, GCHandleType.Pinned);

            using (Image<Gray, byte> yv12p = new Image<Gray, byte>(width, (height >> 1) * 3, width, handle.AddrOfPinnedObject()))
            {
                CvInvoke.CvtColor(yv12p, image, Emgu.CV.CvEnum.ColorConversion.Yuv420P2Bgr);
            }

            if (handle.IsAllocated)
            {
                handle.Free();
            }

            return image;
        }

        public Bitmap Yv12_2_BGR_BitMap(ref IntPtr pBuf, int nSize, int height, int width)
        {
            Bitmap tempBitMap = Yv12_2_BGR(ref pBuf, nSize, height, width).ToBitmap();

            return tempBitMap;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Views
{
    public static class Utilitary
    {

        public static Bitmap ByteToImage(byte[] blob)
        {
            Bitmap bmp = null;
            if (blob.Length > 0) 
            {
                using (var ms = new MemoryStream(blob))
                {
                    bmp = new Bitmap(ms);
                }

            }
            return bmp;
        }

        public static byte[] GetBytesFromImage(String imageFile)
        {
            MemoryStream ms = new MemoryStream();
            Image img = Image.FromFile(imageFile);
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }



    }
}

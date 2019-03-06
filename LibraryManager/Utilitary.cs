using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static string CleanFileName(string filename)
        {
            return Regex.Replace(filename, "[^a-zA-Z0-9_. ]+", "", RegexOptions.Compiled);
        }

        public static string GetFileNameFromPath(string filePath) 
        {
            string fileName = Path.GetFileName(filePath);
            fileName = fileName.Replace(Path.GetExtension(fileName), "");
            fileName = CleanFileName(fileName);
            if (fileName.Length > 30) 
            {
                fileName = fileName.Substring(0, 30);
            }
            return fileName;
        }

    }
}

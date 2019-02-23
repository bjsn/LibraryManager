using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;


namespace LibraryManager.Core
{
    public class FileController
    {
        public bool IsFileInUse(string filePath) 
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {}
                System.GC.Collect();
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        public bool OpenFile(string filePath) 
        {
            if (File.Exists(filePath)) 
            {
                try
                {
                    Word.Application  app = new Word.Application();
                    app.Visible = true;
                    Word.Document document = app.Documents.Open(filePath);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return false;
        }


        public string CreateFileCopy(string filePath) 
        {
            try
            {
                string tempPath = Path.GetDirectoryName(filePath);
                string fileCopy = tempPath +"\\"+ Guid.NewGuid().ToString() + Path.GetExtension(filePath);
                File.Copy(filePath, fileCopy);
                return fileCopy;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public bool AreFilesEqual(string filePath, string copyFilePath) 
        {
            try
            {
                byte[] file1 = File.ReadAllBytes(filePath);
                byte[] file2 = File.ReadAllBytes(copyFilePath);
                if (file1.Length == file2.Length)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        if (file1[i] != file2[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public void DeleteFile(string filePath) 
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public byte[] GetBinaryFile(string filePath)
        {
            byte[] bytes;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }
            return bytes;
        }



    }
}

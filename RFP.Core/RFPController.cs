using Microsoft.Office.Interop.Word;
using RFP.Data;
using RFP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFP.Core
{
    public class RFPController: BaseController
    {
        private Data.RFPContentDL RFPContentDL;
        private Application wordApp;
        public RFPController() 
        {
            RFPContentDL = new RFPContentDL(this.DBConnectionPath) { DbPwd = this.DBPW };
            wordApp = new Application();
        }

        public List<RFPContent> GetAll()
        {
            try
            {
                return RFPContentDL.GetAll();
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        public void UpdateRFTById(int RFPId, string name, string RTFtext) 
        {
            try
            {
                byte[] ByteDocx = ConvertRTFInDOXC(name, RTFtext);
                RFPContentDL.UpdateRFPByID(RFPId, RTFtext, ByteDocx);
                
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            } 
        }

        /// <summary>
        /// </summary>
        /// <param name="coincidence"></param>
        /// <returns></returns>
        public List<RFPContent> GetByCoincidence(string coincidence)
        {
            try
            {
                return RFPContentDL.GetByKeyWord(coincidence);
            }
            catch (Exception exception1)
            {
                throw new Exception(exception1.Message);
            }
        }

        private byte[] ConvertRTFInDOXC(string name, string RTF)
        {
            try
            {
                if (wordApp == null)
                {
                    wordApp = new Application();
                }
                string tempPath = System.IO.Path.GetTempPath();
                string path = tempPath + "RFTTemp.rtf";
                if (!File.Exists(path))
                {
                    using (var txtFile = File.AppendText(path))
                    {
                        txtFile.WriteLine(RTF);
                    }
                }
                else if (File.Exists(path))
                {
                    using (var txtFile = File.AppendText(path))
                    {
                        txtFile.WriteLine(RTF);
                    }
                }

                var currentDoc = wordApp.Documents.Open(tempPath + "RFTTemp.rtf");
                string pathTosave = tempPath + "wordRftTemp.doxc";
                currentDoc.SaveAs(pathTosave);
                currentDoc.Close();
                wordApp.Quit();
                return GetBinaryFile(pathTosave);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private byte[] GetBinaryFile(string filename)
        {
            try
            {
                byte[] bytes;
                using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                }
                return bytes;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        public string GetXLAPath() 
        {
            return this.DIRECTORY_ROOT + "PQuote/PQFunct.xla";
        }

    }
}

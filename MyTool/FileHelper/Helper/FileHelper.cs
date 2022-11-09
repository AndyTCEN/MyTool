using System;
using System.IO;
using UploadHelper.Unit.SaveFileByBsae64Unit;

namespace UploadHelper.Helper
{
    public class FileHelper
    {
        public static void SaveFileByBase64(SaveFileByBase64BaseModel base64model)
        {
            if (base64model.folderName.Length == 0 || base64model.fileName.Length == 0 || base64model.base64Str.Length == 0)
                return;
            string fileFullName = CreateFolder(base64model.folderName, base64model.fileName);
            SaveFile(fileFullName, base64model.base64Str);
        }

        private static string CreateFolder(string uploadFolderName, string fileName)
        {
            if (!Directory.Exists(uploadFolderName))
            {
                Directory.CreateDirectory(uploadFolderName);
            }
            return Path.Combine(uploadFolderName, fileName);
        }

        private static void SaveFile(string fileFullName, string base64Str)
        {
            using (FileStream fileStream = new FileStream(fileFullName, FileMode.Create))
            {
                byte[] bytes = Convert.FromBase64String(base64Str);
                fileStream.Write(bytes, 0, bytes.Length);
                fileStream.Flush();
            }
        }

        public static string GetFileToBase64(string filePath)
        {
            string base64Str = string.Empty;
            if (!File.Exists(filePath))
                return base64Str;
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                byte[] bs = new byte[fileStream.Length];
                int log = Convert.ToInt32(fileStream.Length);
                fileStream.Read(bs, 0, log);
                base64Str = Convert.ToBase64String(bs);
                return base64Str;
            }
        }

        public static void DelFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}

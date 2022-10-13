using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UploadHelper.Helper
{
    public class FileHelper
    {
        public static void SaveFileByBase64(string uploadFolderName, string fileName, string base64Str)
        {
            string fileFullName = CreateFolder(uploadFolderName, fileName);
            SaveFile(fileFullName, base64Str);
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
    }
}

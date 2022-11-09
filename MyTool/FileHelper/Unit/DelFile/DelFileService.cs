using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using UploadHelper.Helper;

namespace UploadHelper.Unit.DelFile
{
    public class DelFileService : IDelFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string rootPath;

        public DelFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            rootPath = Path.Combine(_webHostEnvironment.ContentRootPath, "FileUploadFolder");
        }

        public void DelFile(string fileName, string fileExtensionName)
        {
            string filePath = GetFileFullPath(fileName, fileExtensionName);
            FileHelper.DelFile(filePath);
        }

        private string GetFileFullPath(string fileName, string fileExtensionName)
        {
            string filePath = rootPath;
            switch (fileExtensionName)
            {
                case ".pdf":
                    filePath = Path.Combine(filePath, "pdf");
                    break;
                case ".mp3":
                    filePath = Path.Combine(filePath, "mp3");
                    break;
                case ".png":
                    filePath = Path.Combine(filePath, "image");
                    break;
                case ".jpg":
                    filePath = Path.Combine(filePath, "image");
                    break;
                default:
                    break;
            }
            string fullName = string.Concat(fileName, fileExtensionName);
            filePath = Path.Combine(filePath, fullName);
            return filePath;
        }
    }
}

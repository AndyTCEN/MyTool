using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using UploadHelper.Helper;

namespace UploadHelper.Unit.GetFileByPathToBase64Unit
{
    public class GetFileService : IGetFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string rootPath;

        public GetFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            rootPath =Path.Combine(_webHostEnvironment.ContentRootPath, "FileUploadFolder");
        }

        public Dictionary<string, string> GetFilesBase64IEnumerable(Dictionary<string, string> fileInfo)
        {
            Dictionary<string, string> base64strs = new Dictionary<string, string>();
            foreach (var item in fileInfo)
            {
                string base64str = this.GetFileBase64ByFileName(item.Key, item.Value);
                string filename = string.Concat(item.Key, item.Value);
                base64strs.Add(filename, base64str);
            }
            return base64strs;
        }

        public string GetFileBase64ByFileName(string fileName,string fileExtensionName)
        {    
            string filePath = GetFileFullPath(fileName, fileExtensionName);
            string base64str = GetBase64byPath(filePath, fileExtensionName);
            return base64str;
        }

        public string GetFileBase64ByFileNameWithFolder(string fileName,string fileExtensionName,string folderName)
        {

            string filePath = GetFileFullPathWithFolder(fileName, fileExtensionName, folderName);
            string base64str = GetBase64byPath(filePath, fileExtensionName);
            return base64str;
        }

        private string GetFileFullPathWithFolder(string fileName, string fileExtensionName, string folderName)
        {   
            string filePath = rootPath;
            string fullName = string.Concat(fileName, fileExtensionName);
            filePath = Path.Combine(filePath, folderName, fullName);
            return filePath;
        }

        private string GetFileFullPath(string fileName, string fileExtensionName)
        {   
            string filePath = rootPath;
            switch (fileExtensionName)
            {
                case ".pdf":
                    filePath = Path.Combine(filePath,"pdf");
                    break;
                case ".mp3":
                    filePath = Path.Combine(filePath,"mp3");
                    break;
                case ".png":
                    filePath = Path.Combine(filePath,"image");
                    break;
                case ".jpg":
                    filePath = Path.Combine(filePath,"image");
                    break;
                default:                    
                    break;
            }
            string fullName = string.Concat(fileName, fileExtensionName);
            filePath = Path.Combine(filePath,fullName);
            return filePath;
        }

        private string GetBase64byPath(string filePath, string fileExtensionName)
        {
            string base64str = FileHelper.GetFileToBase64(filePath);
            string fileType = string.Empty;
            switch (fileExtensionName)
            {
                case ".pdf":
                    fileType = "data:application/pdf;base64,";
                    break;
                case ".mp3":
                    fileType = "data:audio/mpeg;base64,";
                    break;
                case ".png":
                    fileType = "data:image/png;base64,";
                    break;
                case ".jpg":
                    fileType = "data:image/jpeg;base64,";
                    break;
                default:
                    break;
            }
            return string.Concat(fileType, base64str);
        }

       
    }
}

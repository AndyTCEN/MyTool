using Microsoft.AspNetCore.Hosting;
using System;
using UploadHelper.Helper;

namespace UploadHelper.Unit.SaveFileByBsae64Unit
{
    public class SaveFileByBase64Service: ISaveFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SaveFileByBase64Service(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        }

        public void UpLoadFile(string fileName,string fileBase64)
        {   
            var base64model = CreateFileInfoByFileExtendName(fileName, fileBase64);
            FileHelper.SaveFileByBase64(base64model);
        }

        public void UpLoadFile(string fileName, string folderName, string fileBase64)
        {
            var base64model = CreateFileInfoByFileExtendNameWithFolder(fileName, folderName, fileBase64);
            FileHelper.SaveFileByBase64(base64model);
        }

        private SaveFileByBase64BaseModel CreateFileInfoByFileExtendName(string fileName, string fileBase64)
        {
            string rootpath = _webHostEnvironment.ContentRootPath;
            SaveFileByBase64Unit dto = new SaveFileByBase64Unit(rootpath, fileName, fileBase64);
            return dto.CreateModel();
        }

        private SaveFileByBase64BaseModel CreateFileInfoByFileExtendNameWithFolder(string fileName, string folerName, string fileBase64)
        {
            string rootpath = _webHostEnvironment.ContentRootPath;
            SaveFileByBase64WithFolderUnit dto = new SaveFileByBase64WithFolderUnit(rootpath, fileName, folerName, fileBase64);
            return dto.CreateModel();
        }
    }
}

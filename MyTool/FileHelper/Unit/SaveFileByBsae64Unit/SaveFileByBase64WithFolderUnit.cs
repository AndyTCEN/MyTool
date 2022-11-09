using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadHelper.Unit.SaveFileByBsae64Unit
{
    public class SaveFileByBase64WithFolderUnit
    {
        private readonly string _rootpath;
        private readonly string _fileName;
        private readonly string _folerName;
        private readonly string _fileBase64;
        private readonly string _fileExtendName;


        public SaveFileByBase64WithFolderUnit(string rootpath, string fileName, string folerName, string fileBase64)
        {
            this._rootpath = rootpath;
            _fileName = fileName ?? string.Empty;
            _folerName = folerName ?? string.Empty;

            var strarray = fileBase64.Split(",");
            _fileExtendName = strarray[0] ?? string.Empty;
            _fileBase64 = strarray[1] ?? string.Empty;
        }

        internal SaveFileByBase64BaseModel CreateModel()
        {
            switch (_fileExtendName)
            {
                case var a when a.Contains("application/pdf"):
                    return new  SaveFileByBase64PdfWithFolderModel (_rootpath, this._fileName, this._folerName, this._fileBase64);
                case var a when a.Contains("audio/mpeg"):
                    return new SaveFileByBase64Mp3WithFolderModel(_rootpath, this._fileName, this._folerName, this._fileBase64);
                case var a when a.Contains("image/png"):
                    return new SaveFileByBase64PngWithFolderModel(_rootpath, this._fileName,this._folerName, this._fileBase64);
                case var a when a.Contains("image/jpeg"):
                    return new SaveFileByBase64JpgWithFolderModel(_rootpath, this._fileName, this._folerName, this._fileBase64);
                default:
                    throw new ArgumentNullException("No File");
            }
        }
    }
}

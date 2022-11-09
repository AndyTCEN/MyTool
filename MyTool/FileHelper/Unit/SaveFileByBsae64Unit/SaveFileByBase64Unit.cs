using System;

namespace UploadHelper.Unit.SaveFileByBsae64Unit
{
    public class SaveFileByBase64Unit
    {
        private readonly string _fileName;
        private readonly string _fileBase64;
        private readonly string _fileExtendName;
        private readonly string _rootPath;      


        public SaveFileByBase64Unit(string rootPath,string fileName, string fileBase64)
        {
            this._rootPath = rootPath;
            _fileName = fileName ?? string.Empty;

            var strarray= fileBase64.Split(",");
            _fileExtendName = strarray[0]??string.Empty;
            _fileBase64 = strarray[1] ??string.Empty;
        }

        public SaveFileByBase64BaseModel CreateModel()
        {
            switch (_fileExtendName)
            {
                case var a when a.Contains("application/pdf"):
                    return new SaveFileByBase64PdfModel(_rootPath, this._fileName,this._fileBase64);
                case var a when a.Contains("audio/mpeg"):
                    return new SaveFileByBase64Mp3Model(_rootPath, this._fileName, this._fileBase64);
                case var a when a.Contains("image/png"):
                    return new SaveFileByBase64PngModel(_rootPath, this._fileName, this._fileBase64);
                case var a when a.Contains("image/jpeg"):
                    return new SaveFileByBase64JpgModel(_rootPath, this._fileName, this._fileBase64);
                default:
                    throw new ArgumentNullException("No File");
            }
        }
    }
}

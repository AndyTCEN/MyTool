using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UploadHelper.Unit.SaveFileByBsae64Unit
{
    public abstract class SaveFileByBase64BaseModel
    {
        
        public string rootfolder { get => this._rootfolder; set => this._rootfolder = value; }
        protected string _rootfolder;
        public string folderName { get=> CreateFolderName(); set=>this._folderName=value; }
        protected string _folderName;

        public string fileName { get => CreateFileName(); set => this._fileName = value; }
        protected string _fileName;

        public string base64Str { get => this._base64Str; set => this._base64Str = value; }
        protected string _base64Str;

        protected SaveFileByBase64BaseModel(string rootPath,string fileName, string base64Str)
        {
            this._fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            this._base64Str = base64Str ?? throw new ArgumentNullException(nameof(base64Str));
            this._rootfolder = Path.Combine(rootPath, "FileUploadFolder");
        }


        protected abstract string CreateFileName();
        protected abstract string CreateFolderName();
    }

    public class SaveFileByBase64PdfModel : SaveFileByBase64BaseModel
    {
        public SaveFileByBase64PdfModel(string rootPath, string fileName, string base64Str) : base(rootPath, fileName, base64Str)
        {
        }

        protected override string CreateFileName()
        {
            return string.Concat(this._fileName, ".pdf");
        }

        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder, $"pdf");
        }
    }
    public class SaveFileByBase64Mp3Model : SaveFileByBase64BaseModel
    {
        public SaveFileByBase64Mp3Model(string rootPath, string fileName, string base64Str) : base(rootPath, fileName, base64Str)
        {
        }

        protected override string CreateFileName()
        {
            return string.Concat(this._fileName, ".mp3");
        }

        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder, $"mp3");
        }
    }
    public class SaveFileByBase64PngModel : SaveFileByBase64BaseModel
    {
        public SaveFileByBase64PngModel(string rootPath, string fileName, string base64Str) : base(rootPath, fileName, base64Str)
        {
        }

        protected override string CreateFileName()
        {
            return string.Concat(this._fileName, ".png");
        }

        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder, $"image");
        }
    }
    public class SaveFileByBase64JpgModel : SaveFileByBase64BaseModel
    {
        public SaveFileByBase64JpgModel(string rootPath, string fileName, string base64Str) : base(rootPath, fileName, base64Str)
        {
        }

        protected override string CreateFileName()
        {
            return string.Concat(this._fileName, ".jpg");
        }

        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder, $"image");
        }
    }

    public class SaveFileByBase64JpgWithFolderModel : SaveFileByBase64JpgModel
    {   
        public SaveFileByBase64JpgWithFolderModel(string rootPath, string fileName,string folderName, string base64Str) : base(rootPath, fileName, base64Str)
        {
            this._folderName = folderName;
        }
       
        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder,this._folderName);
        }
    }

    public class SaveFileByBase64PngWithFolderModel : SaveFileByBase64PngModel
    {
        public SaveFileByBase64PngWithFolderModel(string rootPath, string fileName, string folderName, string base64Str) : base(rootPath, fileName, base64Str)
        {
            this._folderName = folderName;
        }

        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder, this._folderName);
        }
    }

    public class SaveFileByBase64Mp3WithFolderModel : SaveFileByBase64Mp3Model
    {
        public SaveFileByBase64Mp3WithFolderModel(string rootPath, string fileName, string folderName, string base64Str) : base(rootPath, fileName, base64Str)
        {
            this._folderName = folderName;
        }

        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder, this._folderName);
        }
    }

    public class SaveFileByBase64PdfWithFolderModel : SaveFileByBase64PdfModel
    {
        public SaveFileByBase64PdfWithFolderModel(string rootPath, string fileName, string folderName, string base64Str) : base(rootPath, fileName, base64Str)
        {
            this._folderName = folderName;
        }

        protected override string CreateFolderName()
        {
            return Path.Combine(this.rootfolder, this._folderName);
        }
    }
}

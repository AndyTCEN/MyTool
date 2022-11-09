using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadHelper.Unit.SaveFileByBsae64Unit
{
    public interface ISaveFileService
    {
        void UpLoadFile(string fileName,string fileBase64);

        void UpLoadFile(string fileName,string folderName, string fileBase64);
    }
}

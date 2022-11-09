using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadHelper.Unit.DelFile
{
    public interface IDelFileService
    {
        void DelFile(string fileName, string fileExtensionName);
    }
}

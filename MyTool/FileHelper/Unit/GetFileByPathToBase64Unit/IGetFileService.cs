using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadHelper.Unit.GetFileByPathToBase64Unit
{
    public interface IGetFileService
    {
        string GetFileBase64ByFileName(string fileName, string fileExtensionName);

        string GetFileBase64ByFileNameWithFolder(string fileName, string fileExtensionName, string folderName);
        /// <summary>
        /// Dictionary(檔名、副檔名)找出檔案位置，並轉成IEnumerable Base64字串
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        Dictionary<string, string> GetFilesBase64IEnumerable(Dictionary<string, string> fileInfo);
    }
}

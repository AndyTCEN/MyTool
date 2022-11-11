using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_CMS.Controllers.ViewModels.FileViewModel;
using UBOT_CMS.Services.DTO;

namespace UBOT_CMS.Services.Interfaces
{
    public interface ICarouselFileService<T>
    {
        Task<bool> AddNewFileInfo(T t);
        Task<bool> ModifyFileInfo(T t);
        Task<IEnumerable<CarouselRsp>> GetAllCarousel_Use(string picUsed);
        Task<CarouselInfoRsp> GetSingleCarousel_Use(string sid);
        Task DelFileInfo(string sid);
    }
}

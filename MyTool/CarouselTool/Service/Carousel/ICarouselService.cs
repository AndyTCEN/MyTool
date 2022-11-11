using System.Collections.Generic;
using System.Threading.Tasks;
using UBOT_CMS.Controllers.ViewModels;
using UBOT_CMS.Controllers.ViewModels.FileViewModel;

namespace UBOT_CMS.Services.Interfaces
{
    public interface ICarouselService
    {
       Task AddOrModifyCarouselPicture(CarouselAddOrModifyPictureViewModel vm);

        Task<ResponseViewModel> GetAllCarousel_Use(string picUsed);
        Task<ResponseViewModel> QueryCarouselInfo(string sid);
        Task DelCarouselInfo(string sid);
        Task ModifyCarouselOrder(IEnumerable<CarouselAddOrModifyPictureViewModel> vm);
    }
}

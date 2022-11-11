using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_CMS.Controllers.ViewModels;
using UBOT_CMS.Controllers.ViewModels.FileViewModel;
using UBOT_CMS.Repositories.Intefaces;
using UBOT_CMS.Services.DTO;
using UBOT_CMS.Services.Interfaces;

namespace UBOT_CMS.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly ICarouselFileService<CarouselAddOrModifyPictureViewModel> _fileService;
        private readonly ICarouselFileRepository _carouselFileRepository;

        public CarouselService(ICarouselFileService<CarouselAddOrModifyPictureViewModel> fileService, ICarouselFileRepository carouselFileRepository)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _carouselFileRepository = carouselFileRepository ?? throw new ArgumentNullException(nameof(carouselFileRepository));
        }

        public async Task AddOrModifyCarouselPicture(CarouselAddOrModifyPictureViewModel vm)
        {   
            if (string.IsNullOrEmpty(vm.carousel_sid))
                await _fileService.AddNewFileInfo(vm);
            else
                await  _fileService.ModifyFileInfo(vm);
        }

        public async Task DelCarouselInfo(string sid)
        {
            await _fileService.DelFileInfo(sid);
        }

        public async Task<ResponseViewModel> GetAllCarousel_Use(string picUsed)
        {
            IEnumerable<CarouselRsp>  rsps=await _fileService.GetAllCarousel_Use(picUsed);
            return new ResponseViewModel { RtnData = rsps };
        }

        public async Task ModifyCarouselOrder(IEnumerable<CarouselAddOrModifyPictureViewModel> vm)
        {
            if (vm.Count()==0)
                return;
            await _carouselFileRepository.ModifyOrderCarousel_Use(vm);
        }

        public async Task<ResponseViewModel> QueryCarouselInfo(string sid)
        {
            CarouselInfoRsp vm = await _fileService.GetSingleCarousel_Use(sid);
            return new ResponseViewModel {  RtnData= vm};
        }
    }
}

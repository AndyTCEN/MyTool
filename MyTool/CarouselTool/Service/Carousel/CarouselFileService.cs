using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_CMS.Common.Unit.DelFile;
using UBOT_CMS.Common.Unit.GetFileByPathToBase64Unit;
using UBOT_CMS.Common.Unit.SaveFileByBsae64Unit;
using UBOT_CMS.Controllers.ViewModels.FileViewModel;
using UBOT_CMS.Repositories.Intefaces;
using UBOT_CMS.Services.DTO;
using UBOT_CMS.Services.Interfaces;

namespace UBOT_CMS.Services
{
    public class CarouselFileService : ICarouselFileService<CarouselAddOrModifyPictureViewModel>
    {
        private readonly IFileInfoRepository<FileInfoBaseReq> _fileInfoRepository;
        private readonly ISaveFileService _saveFileService;
        private readonly IMapper _mapper;
        private readonly ICarouselFileRepository _carouselFileRepository;
        private readonly IGetFileService _getFileService;
        private readonly IDelFileService _delFileService;

        public CarouselFileService(IFileInfoRepository<FileInfoBaseReq> fileInfoRepository, ISaveFileService saveFileService, IMapper mapper, ICarouselFileRepository carouselFileRepository, IGetFileService getFileService, IDelFileService delFileService)
        {
            _fileInfoRepository = fileInfoRepository ?? throw new ArgumentNullException(nameof(fileInfoRepository));
            _saveFileService = saveFileService ?? throw new ArgumentNullException(nameof(saveFileService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _carouselFileRepository = carouselFileRepository ?? throw new ArgumentNullException(nameof(carouselFileRepository));
            _getFileService = getFileService ?? throw new ArgumentNullException(nameof(getFileService));
            _delFileService = delFileService ?? throw new ArgumentNullException(nameof(delFileService));
        }

        public async Task<bool> AddNewFileInfo(CarouselAddOrModifyPictureViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.picFileStr))
                return false;
            try
            {
                vm.picFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                FileInfoBaseReq dto = _mapper.Map<FileInfoBaseReq>(vm);
                var filersp = await _fileInfoRepository.AddNewFileInfo(dto);
                string use_id = await _carouselFileRepository.AddNewCarousel_Use(vm.PicUsed, filersp.sid);
                if (!string.IsNullOrEmpty(filersp.sid))
                    _saveFileService.UpLoadFile(vm.picFileName, vm.picFileStr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task DelFileInfo(string sid)
        {
            string file_sid = await _carouselFileRepository.DelCarousel_Use(sid);
            var filersp= await _fileInfoRepository.DelFileInfo(file_sid);
            if (!string.IsNullOrEmpty(file_sid))
                _delFileService.DelFile(filersp.fileName,filersp.fileExtensionName);
        }

        public async Task<IEnumerable<CarouselRsp>> GetAllCarousel_Use(string picUsed)
        {
            var entities =await _carouselFileRepository.GetAllCarousel_Use(picUsed);            
            Dictionary<string, string> fileInfo = entities.ToDictionary(r => r.fileName, r => r.fileExtensionName);
            var base64s = _getFileService.GetFilesBase64IEnumerable(fileInfo); 
            IEnumerable<CarouselRsp> rsps =_mapper.Map < IEnumerable<CarouselRsp>>(entities);
            #region "將Base64字串指派給rsps"
            rsps.ToList().ForEach(r => r.picFileBase64Str = base64s.FirstOrDefault(p => p.Key == string.Concat(r.picFileName, r.picFileExtensionName)).Value); 
            #endregion

            return rsps;
        }

        public async Task<CarouselInfoRsp> GetSingleCarousel_Use(string sid)
        {
            var entities = await _carouselFileRepository.GetSingleCarousel_Use(sid);
            CarouselInfoRsp rsps = _mapper.Map<CarouselInfoRsp>(entities);
            return rsps;
        }

        public async Task<bool> ModifyFileInfo(CarouselAddOrModifyPictureViewModel vm)
        {
            FileInfoBaseReq dto = _mapper.Map<FileInfoBaseReq>(vm);
            var file = await _fileInfoRepository.ModifyFileInfo(dto);
            var result = await _carouselFileRepository.ModifyCarousel_Use(vm.carousel_sid,vm.PicUsed,vm.image_Order);
            if (!string.IsNullOrEmpty(file.fileName)&&!string.IsNullOrEmpty(vm.picFileStr))
                _saveFileService.UpLoadFile(file.fileName, vm.picFileStr);
            return true;
        }
    }
}

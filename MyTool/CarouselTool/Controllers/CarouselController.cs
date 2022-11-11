using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_CMS.Services.Interfaces;

namespace CarouselTool.Controllers
{
    public class CarouselController : Controller
    {
        private readonly ICarouselService _carouselService;

        public CarouselController(ICarouselService carouselService)
        {
            _carouselService = carouselService ?? throw new ArgumentNullException(nameof(carouselService));
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CarouselTable(string picUsed)
        {
            var vm = await _carouselService.GetAllCarousel_Use(picUsed);
            ViewData["ShowRole"] = picUsed;
            return View(vm.RtnData);
        }

        [HttpPost]
        [Authorize("Permission")]
        public async Task ModifyCarouselOrder(IEnumerable<CarouselAddOrModifyPictureViewModel> vm)
        {
            await _carouselService.ModifyCarouselOrder(vm);
        }

        [HttpPost]
        [Authorize("Permission")]
        public async Task<IActionResult> CarouselInfoDelete(string sid)
        {
            await _carouselService.DelCarouselInfo(sid);
            return RedirectToAction("CarouselTable");
        }

        [Authorize("Permission")]
        public async Task<IActionResult> AddOrModifyPicture(string sid)
        {
            ViewData["ShowRole"] = sid;
            if (string.IsNullOrEmpty(sid))
                return View();
            var vm = await _carouselService.QueryCarouselInfo(sid);
            return View(vm.RtnData);
        }
        [HttpPost]
        [Authorize("Permission")]
        public async Task<IActionResult> AddOrModifyPicture(CarouselAddOrModifyPictureViewModel vm)
        {
            await _carouselService.AddOrModifyCarouselPicture(vm);
            return RedirectToAction("CarouselTable");
        }
    }
}
}

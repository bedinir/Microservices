using Mango.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Mongo.Web.Service.IService;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mongo.Web.Controllers
{
    public class CuponController : Controller
    {
        private readonly ICuponService _cuponService;

        public CuponController(ICuponService cuponService)
        {
            _cuponService = cuponService;
        }

        public async Task<IActionResult> CuponIndex()
        {
            List<CuponDto>? list = new();
            ResponseDto? response = await _cuponService.GetAllCuponsAsync();
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CuponDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CuponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CuponCreate(CuponDto cuponDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _cuponService.CreateCuponsAsync(cuponDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CuponIndex));
                }
            }
            return View(cuponDto);
        }
    }
}

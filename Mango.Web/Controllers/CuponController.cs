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
            else
            {
                TempData["error"] = response?.Message;
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
                    TempData["success"] = "Cupon created successfully";
                    return RedirectToAction(nameof(CuponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(cuponDto);
        }

        public async Task<IActionResult> CuponDelete(int cuponId)
        {
			ResponseDto? response = await _cuponService.GetCuponByIdAsync(cuponId);
			if (response != null && response.IsSuccess)
			{
				CuponDto? model = JsonConvert.DeserializeObject<CuponDto>(Convert.ToString(response.Result));
                return View(model);
			}
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CuponDelete(CuponDto cuponDto)
        {
            ResponseDto? response = await _cuponService.DeleteCuponsAsync(cuponDto.CuponId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cupon deleted successfully";
                return RedirectToAction(nameof(CuponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(cuponDto);
        }
    }
}

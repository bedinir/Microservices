using Mango.Web.Models;
using Mongo.Web.Models;
using Mongo.Web.Service.IService;
using Mongo.Web.Utility;

namespace Mongo.Web.Service
{
    public class CuponService : ICuponService
    {
        private readonly IBaseService _baseService;

        public CuponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCuponsAsync(CuponDto cuponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data= cuponDto,
                Url = SD.CuponAPIBase + "/api/cupon/"
            });
        }

        public async Task<ResponseDto?> DeleteCuponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CuponAPIBase + "/api/cupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCuponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CuponAPIBase + "/api/cupon"
            });
        }

        public async Task<ResponseDto?> GetCuponAsync(string cuponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CuponAPIBase + "/api/cupon/getByCode/"+cuponCode
            });
        }

        public async Task<ResponseDto?> GetCuponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CuponAPIBase + "/api/cupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCuponsAsync(CuponDto cupon)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = cupon,
                Url = SD.CuponAPIBase + "/api/cupon/"
            });
        }
    }
}

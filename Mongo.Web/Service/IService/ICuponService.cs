using Mango.Web.Models;

namespace Mongo.Web.Service.IService
{
    public interface ICuponService
    {
        Task<ResponseDto?> GetCuponAsync(string cuponCode);
        Task<ResponseDto?> GetAllCuponsAsync();
        Task<ResponseDto?> GetCuponByIdAsync(int id);
        Task<ResponseDto?> CreateCuponsAsync(CuponDto cupon);
        Task<ResponseDto?> UpdateCuponsAsync(CuponDto cupon);
        Task<ResponseDto?> DeleteCuponsAsync(int id);


    }
}

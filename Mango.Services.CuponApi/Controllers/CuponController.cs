using AutoMapper;
using Mango.Services.CuponApi.Data;
using Mango.Services.CuponApi.Models;
using Mango.Services.CuponApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CuponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CuponController(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Cupon> objList = _db.Cupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CuponDto>>(objList);
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Cupon cupon = _db.Cupons.First(u => u.CuponId == id);
                _response.Result = _mapper.Map<Cupon>(cupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}

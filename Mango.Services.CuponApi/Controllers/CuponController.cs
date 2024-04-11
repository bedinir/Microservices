using AutoMapper;
using Mango.Services.CuponApi.Data;
using Mango.Services.CuponApi.Models;
using Mango.Services.CuponApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CuponApi.Controllers
{
    [Route("api/cupon")]
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
                _response.Result = _mapper.Map<CuponDto>(cupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("getByCode/{codeId}")]
        public ResponseDto GetBCode(string codeId)
        {
            try
            {
                Cupon cupon = _db.Cupons.First(c => c.CuponCode.ToLower() == codeId.ToLower());
                if(cupon == null)
                {
                    _response.IsSuccess = false;
                }
                else
                {
                    _response.Result = _mapper.Map<CuponDto>(cupon);
                }
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CuponDto cuponDto)
        {
            try
            {
                Cupon cupon = _mapper.Map<Cupon>(cuponDto);
                _db.Cupons.Add(cupon);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CuponDto>(cuponDto);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] CuponDto cuponDto)
        {
            try
            {
                Cupon cupon = _mapper.Map<Cupon>(cuponDto);
                _db.Cupons.Update(cupon);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CuponDto>(cupon);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Cupon cupon = _db.Cupons.First(c => c.CuponId == id);
                _db.Cupons.Remove(cupon);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}

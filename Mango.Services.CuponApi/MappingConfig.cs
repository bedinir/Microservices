using AutoMapper;
using Mango.Services.CuponApi.Models;
using Mango.Services.CuponApi.Models.Dto;

namespace Mango.Services.CuponApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CuponDto, Cupon>();
                config.CreateMap<Cupon, CuponDto>();
            });

            return mappingConfig;
        }
    }
}

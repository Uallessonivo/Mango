using AutoMapper;
using Mango.Services.CartAPI.Models;
using Mango.Services.CartAPI.Models.Dtos;

namespace Mango.Services.CartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartDetailsDto, CartDetails>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}

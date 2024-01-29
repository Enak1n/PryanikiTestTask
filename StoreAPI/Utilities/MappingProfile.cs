using AutoMapper;
using StoreAPI.Domain.Entities;
using StoreAPI.Infrastructure.DTO;

namespace StoreAPI.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTOResponse>();
            CreateMap<ProductDTORequest, Product>();
            CreateMap<Product, ProductDTORequest>();
        }
    }
}

using System;
using AutoMapper;
using ECommerce.Business.DTOs;
using ECommerce.Data.Models;

namespace ECommerce.Business.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
       /* CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.TaxIncludedPrice,
                       opt => opt.MapFrom(src => src.Price * 1.20m));*/
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.TaxIncludedPrice,
               opt => opt.MapFrom(src => src.Price * 1.20m)); //burada aldığım hatanın sebebini bilmiyorum nasıl çözdüğüm hakkında da bir fikrim yok :(

        CreateMap<ProductUpdateDto, Product>();

        CreateMap<Customer,CustomerDto>();
        CreateMap<CustomerCreateDto,Customer>();
    }
}

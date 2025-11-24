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
        CreateMap<ProductCreateDto, Product>();

        CreateMap<ProductUpdateDto, Product>();

        CreateMap<Customer,CustomerDTO>();
        CreateMap<CustomerCreateDto,Customer>();
    }
}

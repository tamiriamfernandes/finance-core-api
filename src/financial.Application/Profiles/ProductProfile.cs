using AutoMapper;
using financial.Model.DTOs.Product;
using financial.Model.Entities;

namespace financial.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, DetailProductDto>();
    }
}
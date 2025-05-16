using AutoMapper;
using financial.Model.DTOs.Product;
using financial.Model.DTOs.Sale;
using financial.Model.Entities;

namespace MySfinancialales.Application.Profiles;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<InputSaleDto, Sale>();
    }
}

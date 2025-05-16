using AutoMapper;
using financial.Model.Entities;
using financial.Model.DTOs.Client;

namespace financial.Application.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<InputCustomerDto, Customer>();
    }
}

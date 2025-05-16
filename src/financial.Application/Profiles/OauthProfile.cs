using AutoMapper;
using financial.Model.DTOs.User;
using financial.Model.Entities;

namespace financial.Application.Profiles;

public class OauthProfile : Profile
{
    public OauthProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}

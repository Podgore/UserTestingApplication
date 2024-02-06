using AutoMapper;
using UserTestingApp.Common.DTO;
using UserTestingApp.Entities;

namespace UserTestingApp.BLL.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<UserDTO, User>();
    }
}
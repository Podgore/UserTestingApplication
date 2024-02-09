using AutoMapper;
using UserTestingApp.Common.DTO;
using UserTestingApp.Entities;

namespace UserTestingApp.BLL.Profiles;

public class OptionProfile : Profile
{
    public OptionProfile()
    {
        CreateMap<Option, OptionDTO>();
    }
}

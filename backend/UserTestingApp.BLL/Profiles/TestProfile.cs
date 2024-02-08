using AutoMapper;
using UserTestingApp.Common.DTO;
using UserTestingApp.Entities;

namespace UserTestingApp.BLL.Profiles;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<Test, TestDTO>()
            .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => string.Join(", ", src.TestUsers.Select(user => user.Mark))))
            .ForMember(dest => dest.isComplited, opt => opt.MapFrom(src => string.Join(", ", src.TestUsers.Select(user => user.IsComplited))));

        CreateMap<TaskAnswerDTO, UserAnswer>();
    }
}

using AutoMapper;
using UserTestingApp.Common.DTO;
using UserTestingApp.Entities;

namespace UserTestingApp.BLL.Profiles;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<Test, TestDTO>();

        CreateMap<Test, ExtendedTestDTO>();

        CreateMap<TaskAnswerDTO, UserAnswer>();
    }
}




using AutoMapper;
using UserTestingApp.Common.DTO;
using UserTestingApp.Entities;

namespace UserTestingApp.BLL.Profiles;

public class TestTasksProfile : Profile
{
    public TestTasksProfile()
    {
        CreateMap<TestTask, TestTaskDTO>();
    }
}

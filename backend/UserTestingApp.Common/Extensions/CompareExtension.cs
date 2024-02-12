using Microsoft.AspNetCore.Http;
using UserTestingApp.Common.DTO;
using UserTestingApp.Common.Exceptions;
using UserTestingApp.Entities;

namespace UserTestingApp.Common.Extensions;

public static class CompareExtension
{
    public static bool Compare(this TestTask testTask, TaskAnswerDTO taskAnswer)
    {
        var rightAnswer = testTask.Options.FirstOrDefault(option => option.IsComplited == true)
            ?? throw new NoRigthAnswerException($"Task with this Id dont have right answer: {testTask.Id}");

        return taskAnswer.OptionId == rightAnswer.Id;
    }
}

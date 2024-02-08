using FluentValidation;
using UserTestingApp.Common.DTO;

namespace UserTestingApp.Validators.AnswerValidator
{
    public class TaskAnswerValidator : AbstractValidator<TaskAnswerDTO>
    {
        public TaskAnswerValidator() 
        {
            RuleFor(dto => dto.TestTaskId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Task Id can't be empty or null");

            RuleFor(dto => dto.OptionId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Option Id can't be empty or null");
        }
    }
}

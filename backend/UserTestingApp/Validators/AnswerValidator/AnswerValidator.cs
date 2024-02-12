using FluentValidation;
using UserTestingApp.Common.DTO;

namespace UserTestingApp.Validators.AnswerValidator;

public class AnswerValidator : AbstractValidator<UploadAnswerDTO>
{
    public AnswerValidator()
    {
        RuleFor(dto => dto.TestId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Test Id can't be empty or null");

        RuleForEach(dto => dto.TaskAnswers)
            .SetValidator(new TaskAnswerValidator());
    }
}

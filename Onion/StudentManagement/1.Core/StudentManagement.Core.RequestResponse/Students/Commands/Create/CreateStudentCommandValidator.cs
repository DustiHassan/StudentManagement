using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace StudentManagement.Core.RequestResponse.Students.Commands.Create
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator(ITranslator translator)
        {
            RuleFor(c => c.FirstName)
                .NotNull().WithMessage(translator["Required", "FirstName"])
                .MinimumLength(2).WithMessage(translator["MinimumLength", "FirstName", "2"])
                .MaximumLength(100).WithMessage(translator["MaximumLength", "FirstName", "100"]);

            RuleFor(c => c.LastName)
                .NotNull().WithMessage(translator["Required", "LastName"]).WithErrorCode("1")
                .MinimumLength(2).WithMessage(translator["MinimumLength", "LastName", "2"]).WithErrorCode("2")
                .MaximumLength(100).WithMessage(translator["MaximumLength", "LastName", "100"]).WithErrorCode("3");

            RuleFor(c => c.StudentNumber)
                .NotNull().WithMessage(translator["Required", "StudentNumber"]).WithErrorCode("1")
                .MinimumLength(9).WithMessage(translator["MinimumLength", "StudentNumber", "9"]).WithErrorCode("2")
                .MaximumLength(9).WithMessage(translator["MaximumLength", "StudentNumber", "9"]).WithErrorCode("3");

            RuleFor(c => c.NationalCode)
                .NotNull().WithMessage(translator["Required", "NationalCode"]).WithErrorCode("1")
                .MinimumLength(10).WithMessage(translator["MinimumLength", "NationalCode", "10"]).WithErrorCode("2")
                .MaximumLength(10).WithMessage(translator["MaximumLength", "NationalCode", "10"]).WithErrorCode("3");
        }
    }
}

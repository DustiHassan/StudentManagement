using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace StudentManagement.Core.RequestResponse.Students.Queries.GetById;

public class GetStudentByIdQueryValidator : AbstractValidator<GetStudentByIdQuery>
{
    public GetStudentByIdQueryValidator(ITranslator translator)
    {
        RuleFor(query => query.StudentId)
            .NotEmpty()
            .WithMessage(translator["Required", nameof(GetStudentByIdQuery.StudentId)]);
    }
}
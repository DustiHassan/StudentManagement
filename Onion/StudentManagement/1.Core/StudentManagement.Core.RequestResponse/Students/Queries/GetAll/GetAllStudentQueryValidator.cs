using FluentValidation;
using Zamin.Extensions.Translations.Abstractions;

namespace StudentManagement.Core.RequestResponse.Students.Queries.GetAll;

public class GetAllStudentQueryValidator : AbstractValidator<GetAllStudentQuery>
{
    public GetAllStudentQueryValidator(ITranslator translator)
    {
    }
}
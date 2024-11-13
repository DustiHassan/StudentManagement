using StudentManagement.Core.Contracts.Students.Commands;
using StudentManagement.Core.Domain.Students.Entities;
using StudentManagement.Core.RequestResponse.Students.Commands.Create;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Commands.Create;

public class CreateStudentCommandHandler : CommandHandler<CreateStudentCommand, Guid>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public CreateStudentCommandHandler(ZaminServices zaminServices,
                                    IStudentCommandRepository StudentCommandRepository) : base(zaminServices)
    {
        _studentCommandRepository = StudentCommandRepository;
    }

    public override async Task<CommandResult<Guid>> Handle(CreateStudentCommand command)
    {
        Student student = Student.Create(command.FirstName, command.LastName, command.StudentNumber, command.NationalCode);

        await _studentCommandRepository.InsertAsync(student);

        await _studentCommandRepository.CommitAsync();

        return Ok(student.BusinessId.Value);
    }
}

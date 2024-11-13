using StudentManagement.Core.Contracts.Students.Commands;
using StudentManagement.Core.RequestResponse.Students.Commands.Update;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Common;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Commands.Update;

public sealed class UpdateStudentCommandHandler : CommandHandler<UpdateStudentCommand>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public UpdateStudentCommandHandler(ZaminServices zaminServices,
                                    IStudentCommandRepository StudentCommandRepository) : base(zaminServices)
    {
        _studentCommandRepository = StudentCommandRepository;
    }

    public override async Task<CommandResult> Handle(UpdateStudentCommand command)
    {
        var student = await _studentCommandRepository.GetAsync(command.Id);

        if (student is null)
        {
            result.AddMessage("StudentNotFound");
            return Result(ApplicationServiceStatus.NotFound);
        }
        student.Update(command.FirstName, command.LastName, command.StudentNumber, command.NationalCode);

        await _studentCommandRepository.CommitAsync();

        return Ok();
    }
}

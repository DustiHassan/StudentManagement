using StudentManagement.Core.Contracts.Students.Commands;
using StudentManagement.Core.RequestResponse.Students.Commands.Update;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Commands.Update;

public sealed class UpdateStudentCommandHandler : CommandHandler<UpdateStudentCommand>
{
    private readonly IStudentCommandRepository _StudentCommandRepository;

    public UpdateStudentCommandHandler(ZaminServices zaminServices,
                                    IStudentCommandRepository StudentCommandRepository) : base(zaminServices)
    {
        _StudentCommandRepository = StudentCommandRepository;
    }

    public override async Task<CommandResult> Handle(UpdateStudentCommand command)
    {
        var Student = await _StudentCommandRepository.GetAsync(command.Id);

        if (Student is null)
            throw new InvalidEntityStateException("بلاگ یافت نشد");

        Student.Update(command.FirstName, command.LastName, command.StudentNumber, command.NationalCode);

        await _StudentCommandRepository.CommitAsync();

        return Ok();
    }
}

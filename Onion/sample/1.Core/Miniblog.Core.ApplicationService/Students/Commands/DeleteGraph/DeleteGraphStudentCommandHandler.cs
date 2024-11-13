using StudentManagement.Core.Contracts.Students.Commands;
using StudentManagement.Core.RequestResponse.Students.Commands.DeleteGraph;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Commands.DeleteGraph;

public sealed class DeleteGraphStudentCommandHandler : CommandHandler<DeleteGraphStudentCommand>
{
    private readonly IStudentCommandRepository _StudentCommandRepository;

    public DeleteGraphStudentCommandHandler(ZaminServices zaminServices,
                                    IStudentCommandRepository StudentCommandRepository) : base(zaminServices)
    {
        _StudentCommandRepository = StudentCommandRepository;
    }

    public override async Task<CommandResult> Handle(DeleteGraphStudentCommand command)
    {
        var Student = await _StudentCommandRepository.GetAsync(command.Id);

        if (Student is null)
            throw new InvalidEntityStateException("بلاگ یافت نشد");

        Student.DeleteGraph();

        _StudentCommandRepository.DeleteGraph(Student.Id);

        await _StudentCommandRepository.CommitAsync();

        return Ok();
    }
}
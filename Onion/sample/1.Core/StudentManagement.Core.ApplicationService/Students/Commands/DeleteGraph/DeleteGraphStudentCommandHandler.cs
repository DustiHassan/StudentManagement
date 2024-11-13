using StudentManagement.Core.Contracts.Students.Commands;
using StudentManagement.Core.RequestResponse.Students.Commands.DeleteGraph;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Common;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Commands.DeleteGraph;

public sealed class DeleteGraphStudentCommandHandler : CommandHandler<DeleteGraphStudentCommand>
{
    private readonly IStudentCommandRepository _studentCommandRepository;

    public DeleteGraphStudentCommandHandler(ZaminServices zaminServices,
                                    IStudentCommandRepository StudentCommandRepository) : base(zaminServices)
    {
        _studentCommandRepository = StudentCommandRepository;
    }

    public override async Task<CommandResult> Handle(DeleteGraphStudentCommand command)
    {
        var student = await _studentCommandRepository.GetAsync(command.Id);

        if (student is null)
        {
            result.AddMessage("StudentNotFound");
            return Result(ApplicationServiceStatus.NotFound);
        }

        student.DeleteGraph();

        _studentCommandRepository.DeleteGraph(student.Id);

        await _studentCommandRepository.CommitAsync();

        return Ok();
    }
}
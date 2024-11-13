using StudentManagement.Core.Contracts.Students.Commands;
using StudentManagement.Core.Domain.Students.Entities;
using StudentManagement.Core.RequestResponse.Students.Commands.Delete;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Commands;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Commands.Delete;

public sealed class DeleteStudentCommandHandler : CommandHandler<DeleteStudentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentCommandRepository _studentCommandRepository;


    public DeleteStudentCommandHandler(ZaminServices zaminServices,
                                    IUnitOfWork unitOfWork,
                                    IStudentCommandRepository studentCommandRepository) : base(zaminServices)
    {
        _unitOfWork = unitOfWork;
        _studentCommandRepository = studentCommandRepository;
    }

    public override async Task<CommandResult> Handle(DeleteStudentCommand command)
    {
        Student? student = await _studentCommandRepository.GetGraphAsync(command.Id);

        if (student is null)
            throw new InvalidEntityStateException("دانشجو یافت نشد");

        student.Delete();

        _studentCommandRepository.Delete(student);

        await _studentCommandRepository.CommitAsync();

        return Ok();
    }
}

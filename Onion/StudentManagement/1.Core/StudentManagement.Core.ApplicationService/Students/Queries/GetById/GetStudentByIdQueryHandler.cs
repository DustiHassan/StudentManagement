using StudentManagement.Core.Contracts.Students.Queries;
using StudentManagement.Core.RequestResponse.Students.Queries.GetById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Queries.GetById;

public class GetStudentByIdQueryHandler : QueryHandler<GetStudentByIdQuery, StudentQr?>
{
    private readonly IStudentQueryRepository _StudentQueryRepository;

    public GetStudentByIdQueryHandler(ZaminServices zaminServices,
                                   IStudentQueryRepository StudentQueryRepository) : base(zaminServices)
    {
        _StudentQueryRepository = StudentQueryRepository;
    }

    public override async Task<QueryResult<StudentQr?>> Handle(GetStudentByIdQuery query)
    {
        var Student = await _StudentQueryRepository.ExecuteAsync(query);

        return Result(Student);
    }
}

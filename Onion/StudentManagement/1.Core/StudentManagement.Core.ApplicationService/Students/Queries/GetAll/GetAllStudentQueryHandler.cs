using StudentManagement.Core.Contracts.Students.Queries;
using StudentManagement.Core.RequestResponse.Students.Queries.GetAll;
using StudentManagement.Core.RequestResponse.Students.Queries.GetById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace StudentManagement.Core.ApplicationService.Students.Queries.GetAll;

public class GetAllStudentQueryHandler : QueryHandler<GetAllStudentQuery, IEnumerable<StudentQr?>>
{
    private readonly IStudentQueryRepository _studentQueryRepository;

    public GetAllStudentQueryHandler(ZaminServices zaminServices,
                                   IStudentQueryRepository studentQueryRepository) : base(zaminServices)
    {
        _studentQueryRepository = studentQueryRepository;
    }

    public override async Task<QueryResult<IEnumerable<StudentQr?>>> Handle(GetAllStudentQuery query)
    {
        var studentList = await _studentQueryRepository.ExecuteAsync(query);

        return Result(studentList);
    }
}

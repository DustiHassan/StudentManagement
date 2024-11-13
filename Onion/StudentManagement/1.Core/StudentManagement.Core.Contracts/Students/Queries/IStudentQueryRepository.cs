

using StudentManagement.Core.RequestResponse.Students.Queries.GetById;

namespace StudentManagement.Core.Contracts.Students.Queries;

public interface IStudentQueryRepository
{
    public Task<StudentQr?> ExecuteAsync(GetStudentByIdQuery query);
}
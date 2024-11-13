using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Contracts.Students.Queries;
using StudentManagement.Core.RequestResponse.Students.Queries.GetById;
using StudentManagement.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;

namespace StudentManagement.Infra.Data.Sql.Queries.Students;

public class StudentQueryRepository : BaseQueryRepository<StudentManagementQueryDbContext>, IStudentQueryRepository
{
    public StudentQueryRepository(StudentManagementQueryDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<StudentQr?> ExecuteAsync(GetStudentByIdQuery query)
        => await _dbContext.Students.Select(c => new StudentQr()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            StudentNumber = c.StudentNumber,
            NationalCode = c.NationalCode,
        }).FirstOrDefaultAsync(c => c.Id.Equals(query.StudentId));
}

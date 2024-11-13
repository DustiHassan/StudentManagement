using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Contracts.Students.Queries;
using StudentManagement.Core.RequestResponse.Students.Queries.GetAll;
using StudentManagement.Core.RequestResponse.Students.Queries.GetById;
using StudentManagement.Infra.Data.Sql.Queries.Common;
using Zamin.Infra.Data.Sql.Queries;
using Zamin.Utilities.Extensions;

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


    public async Task<IEnumerable<StudentQr?>> ExecuteAsync(GetAllStudentQuery query)
        => await _dbContext.Students.AsNoTracking().Select(c => new StudentQr()
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            StudentNumber = c.StudentNumber,
            NationalCode = c.NationalCode,
        })
        .WhereIf(query.IdFilter.HasValue, c => c.Id.Equals(query.IdFilter))
        .WhereIf(string.IsNullOrEmpty(query.NationalCodeFilter) is false, c => c.NationalCode.Contains(query.NationalCodeFilter))
        .WhereIf(string.IsNullOrEmpty(query.StudentNumberFilter) is false, c => c.StudentNumber.Contains(query.StudentNumberFilter))
        .WhereIf(string.IsNullOrEmpty(query.FirstNameFilter) is false, c => c.FirstName.Contains(query.FirstNameFilter))
        .WhereIf(string.IsNullOrEmpty(query.LastNameFilter) is false, c => c.LastName.Contains(query.LastNameFilter))
        .ToListAsync();


}

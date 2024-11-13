using StudentManagement.Core.Contracts.Students.Commands;
using StudentManagement.Core.Domain.Students.Entities;
using StudentManagement.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace StudentManagement.Infra.Data.Sql.Commands.Students
{
    public class StudentCommandRepository :
        BaseCommandRepository<Student, StudentManagementCommandDbContext, int>,
        IStudentCommandRepository
    {
        public StudentCommandRepository(StudentManagementCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}

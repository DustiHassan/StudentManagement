using StudentManagement.Core.Contracts.People;
using StudentManagement.Core.Domain.People.Entities;
using StudentManagement.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace StudentManagement.Infra.Data.Sql.Commands.People;

public class PersonCommandRepository :
        BaseCommandRepository<Person, StudentManagementCommandDbContext, int>,
        IPersonCommandRepository
{
    public PersonCommandRepository(StudentManagementCommandDbContext dbContext) : base(dbContext)
    {
    }
}

using StudentManagement.Core.Domain.People.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace StudentManagement.Core.Contracts.People;

public interface IPersonCommandRepository : ICommandRepository<Person, int>
{
}

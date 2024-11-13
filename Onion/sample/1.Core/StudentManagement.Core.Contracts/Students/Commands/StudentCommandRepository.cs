using StudentManagement.Core.Domain.Students.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace StudentManagement.Core.Contracts.Students.Commands;

public interface IStudentCommandRepository : ICommandRepository<Student, int>
{
}

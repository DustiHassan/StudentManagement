using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Domain.Students.Entities;
using StudentManagement.Core.Domain.People.Entities;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace StudentManagement.Infra.Data.Sql.Commands.Common
{
    public class StudentManagementCommandDbContext : BaseOutboxCommandDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Person> People { get; set; }
        public StudentManagementCommandDbContext(DbContextOptions<StudentManagementCommandDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Core.Domain.People.Entities;
using StudentManagement.Core.Domain.Students.Entities;
using System.Reflection.Emit;

namespace StudentManagement.Infra.Data.Sql.Commands.Students.Configs;

public sealed class PeopleConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
    }
}
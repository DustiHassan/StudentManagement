using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Core.Domain.Students.Entities;
using System.Reflection.Emit;

namespace StudentManagement.Infra.Data.Sql.Commands.Students.Configs;

public sealed class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(e => e.StudentNumber).HasMaxLength(9);
        builder.Property(e => e.NationalCode).HasMaxLength(10);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
    }
}
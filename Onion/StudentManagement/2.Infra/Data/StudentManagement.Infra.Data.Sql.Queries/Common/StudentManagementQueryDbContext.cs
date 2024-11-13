﻿using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Domain.People.Entities;
using StudentManagement.Infra.Data.Sql.Queries.Students;
using Zamin.Infra.Data.Sql.Queries;

namespace StudentManagement.Infra.Data.Sql.Queries.Common
{
    public partial class StudentManagementQueryDbContext : BaseQueryDbContext
    {
        public StudentManagementQueryDbContext(DbContextOptions<StudentManagementQueryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<OutBoxEventItem> OutBoxEventItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =.; Database = StudentManagementDb; User Id =sa; Password= 1qaz!QAZ; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedByUserId).HasMaxLength(50);

                entity.Property(e => e.ModifiedByUserId).HasMaxLength(50);
                entity.Property(e => e.StudentNumber).HasMaxLength(9);
                entity.Property(e => e.NationalCode).HasMaxLength(10);
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<OutBoxEventItem>(entity =>
            {
                entity.Property(e => e.AccuredByUserId).HasMaxLength(255);

                entity.Property(e => e.AggregateName).HasMaxLength(255);

                entity.Property(e => e.AggregateTypeName).HasMaxLength(500);

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.Property(e => e.EventTypeName).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
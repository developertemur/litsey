using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace litsey.Models
{
    public partial class litseydbContext : DbContext
    {
        public litseydbContext()
        {
        }

        public litseydbContext(DbContextOptions<litseydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupSubject> GroupSubjects { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=litseydb.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasOne(d => d.Profession)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.ProfessionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<GroupSubject>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupSubjects)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GroupSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.Property(e => e.Olimpiada).HasDefaultValueSql("0");

                entity.Property(e => e.Q1).HasDefaultValueSql("0");

                entity.Property(e => e.Q2).HasDefaultValueSql("0");

                entity.Property(e => e.Q3).HasDefaultValueSql("0");

                entity.Property(e => e.Q4).HasDefaultValueSql("0");

                entity.Property(e => e.S1).HasDefaultValueSql("0");

                entity.Property(e => e.S2).HasDefaultValueSql("0");

                entity.Property(e => e.S3).HasDefaultValueSql("0");

                entity.Property(e => e.S4).HasDefaultValueSql("0");

                entity.Property(e => e.Tanlov).HasDefaultValueSql("0");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

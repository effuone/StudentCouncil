using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentCouncil.Data.Models;

namespace StudentCouncil.Data.Data
{
    public partial class StudentCouncilDbContext : DbContext
    {
        public StudentCouncilDbContext()
        {
        }

        public StudentCouncilDbContext(DbContextOptions<StudentCouncilDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CouncilUser> CouncilUsers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Curator> Curators { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentDocument> DepartmentDocuments { get; set; }
        public virtual DbSet<DepartmentMember> DepartmentMembers { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PlanDocument> PlanDocuments { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportDocument> ReportDocuments { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:localhost;D");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.CityName, "QK_Cities_CityName")
                    .IsUnique();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_To_Countries");
            });

            modelBuilder.Entity<CouncilUser>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.CouncilUsers)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CouncilUsers_To_Documents");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.CountryName, "QK_Countries_CountryName")
                    .IsUnique();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curator>(entity =>
            {
                entity.Property(e => e.BecameDate).HasColumnType("date");

                entity.Property(e => e.BecameReason)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Curators)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Curators_To_Departments");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Curators)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Curators_To_Members");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.DepartmentName, "QK_Departments_DepartmentName")
                    .IsUnique();

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepartmentDocument>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentDocuments_To_Departments");

                entity.HasOne(d => d.File)
                    .WithMany()
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentDocuments_To_Documents");
            });

            modelBuilder.Entity<DepartmentMember>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentMembers_To_Departments");

                entity.HasOne(d => d.Member)
                    .WithMany()
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentMembers_To_Members");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.FileId);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupChar)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations_To_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations_To_Countries");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_To_Students");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.Investments).HasColumnType("money");

                entity.Property(e => e.PlanDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PlanShort)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plans_To_Members");
            });

            modelBuilder.Entity<PlanDocument>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LastChangedTime).HasColumnType("datetime");

                entity.HasOne(d => d.File)
                    .WithMany()
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanDocuments_To_Documents");

                entity.HasOne(d => d.Plan)
                    .WithMany()
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanDocuments_To_Plans");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Curator)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CuratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reports_To_Curators");
            });

            modelBuilder.Entity<ReportDocument>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LastChangedTime).HasColumnType("datetime");

                entity.HasOne(d => d.File)
                    .WithMany()
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportDocuments_To_Documents");

                entity.HasOne(d => d.Report)
                    .WithMany()
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportDocuments_To_Reports");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasIndex(e => e.SchoolName, "QK_Schools_SchoolName")
                    .IsUnique();

                entity.Property(e => e.OpeningDate).HasColumnType("date");

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schools_To_Locations");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_To_Groups");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_To_Schools");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

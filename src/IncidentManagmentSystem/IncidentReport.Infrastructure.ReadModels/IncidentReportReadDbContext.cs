using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.ReadModels
{
    public partial class IncidentReportReadDbContext : DbContext
    {
        public IncidentReportReadDbContext()
        {
        }

        public IncidentReportReadDbContext(DbContextOptions<IncidentReportReadDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<DraftApplication> DraftApplication { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<SuspiciousEmployee> SuspiciousEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=IncidentReportDb;User Id=sa;Password=<YourStrong@Passw0rd>;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment", "IncidentReport");

                entity.HasIndex(e => e.DraftApplicationId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.HasOne(d => d.DraftApplication)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.DraftApplicationId);
            });

            modelBuilder.Entity<DraftApplication>(entity =>
            {
                entity.ToTable("DraftApplication", "IncidentReport");

                entity.HasIndex(e => e.ApplicantId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.IncidentTypeValue)
                    .HasColumnName("IncidentType_Value")
                    .HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.DraftApplication)
                    .HasForeignKey(d => d.ApplicantId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "IncidentReport");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);
            });

            modelBuilder.Entity<SuspiciousEmployee>(entity =>
            {
                entity.HasKey(e => new { e.DraftApplicationId, e.Id });

                entity.ToTable("SuspiciousEmployee", "IncidentReport");

                entity.HasIndex(e => e.EmployeeId);

                entity.HasOne(d => d.DraftApplication)
                    .WithMany(p => p.SuspiciousEmployee)
                    .HasForeignKey(d => d.DraftApplicationId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SuspiciousEmployee)
                    .HasForeignKey(d => d.EmployeeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IncidentReport.ReadModels.DbEntities;

#nullable disable

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

        public virtual DbSet<ApplicationAuditLog> ApplicationAuditLogs { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<DraftApplication> DraftApplications { get; set; }
        public virtual DbSet<DraftApplicationAuditLog> DraftApplicationAuditLogs { get; set; }
        public virtual DbSet<DraftApplicationSuspiciousEmployee> DraftApplicationSuspiciousEmployees { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<IncidentApplication> IncidentApplications { get; set; }
        public virtual DbSet<IncidentApplicationSuspiciousEmployee> IncidentApplicationSuspiciousEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplicationAuditLog>(entity =>
            {
                entity.ToTable("ApplicationAuditLog", "IncidentReport");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("Attachment", "IncidentReport");

                entity.HasIndex(e => e.DraftApplicationId, "IX_Attachment_DraftApplicationId");

                entity.HasIndex(e => e.IncidentApplicationId, "IX_Attachment_IncidentApplicationId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.HasOne(d => d.DraftApplication)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.DraftApplicationId);

                entity.HasOne(d => d.IncidentApplication)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.IncidentApplicationId);
            });

            modelBuilder.Entity<DraftApplication>(entity =>
            {
                entity.ToTable("DraftApplication", "IncidentReport");

                entity.HasIndex(e => e.ApplicantId, "IX_DraftApplication_ApplicantId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.IncidentType).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.DraftApplications)
                    .HasForeignKey(d => d.ApplicantId);
            });

            modelBuilder.Entity<DraftApplicationAuditLog>(entity =>
            {
                entity.ToTable("DraftApplicationAuditLog", "IncidentReport");

                entity.HasIndex(e => e.UserId, "IX_DraftApplicationAuditLog_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DraftApplicationAuditLogs)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<DraftApplicationSuspiciousEmployee>(entity =>
            {
                entity.ToTable("DraftApplicationSuspiciousEmployee", "IncidentReport");

                entity.HasIndex(e => e.DraftApplicationId, "IX_DraftApplicationSuspiciousEmployee_DraftApplicationId");

                entity.HasIndex(e => e.EmployeeId, "IX_DraftApplicationSuspiciousEmployee_EmployeeId");

                entity.HasOne(d => d.DraftApplication)
                    .WithMany(p => p.DraftApplicationSuspiciousEmployees)
                    .HasForeignKey(d => d.DraftApplicationId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DraftApplicationSuspiciousEmployees)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "IncidentReport");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Surname).HasMaxLength(100);
            });

            modelBuilder.Entity<IncidentApplication>(entity =>
            {
                entity.ToTable("IncidentApplication", "IncidentReport");

                entity.HasIndex(e => e.ApplicantId, "IX_IncidentApplication_ApplicantId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApplicationStateValue)
                    .HasMaxLength(15)
                    .HasColumnName("ApplicationState_Value");

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.IncidentType).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Applicant)
                    .WithMany(p => p.IncidentApplications)
                    .HasForeignKey(d => d.ApplicantId);
            });

            modelBuilder.Entity<IncidentApplicationSuspiciousEmployee>(entity =>
            {
                entity.ToTable("IncidentApplicationSuspiciousEmployee", "IncidentReport");

                entity.HasIndex(e => e.EmployeeId, "IX_IncidentApplicationSuspiciousEmployee_EmployeeId");

                entity.HasIndex(e => e.IncidentApplicationId, "IX_IncidentApplicationSuspiciousEmployee_IncidentApplicationId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.IncidentApplicationSuspiciousEmployees)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.IncidentApplication)
                    .WithMany(p => p.IncidentApplicationSuspiciousEmployees)
                    .HasForeignKey(d => d.IncidentApplicationId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

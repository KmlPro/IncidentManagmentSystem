using IncidentReport.Domain.Employees;
using IncidentReport.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentReport.Infrastructure.Persistence.DbEntities.Employees
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeDbModel>
    {
        public void Configure(EntityTypeBuilder<EmployeeDbModel> builder)
        {
            builder.ToTable(nameof(Employee), SchemaName.IncidentReport);

            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Surname).HasMaxLength(100).IsRequired();
        }
    }
}

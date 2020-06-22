using System.Collections.Generic;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.EnumDescriptions.IncidentTypes
{
    internal static class IncidentTypeSeed
    {
        internal static void Seed(this ModelBuilder modelBuilder)
        {
            var enumType = nameof(IncidentType);

            modelBuilder.Entity<EnumDescription>().HasData(new List<EnumDescription>()
            {
                new EnumDescription(1,enumType, IncidentType.AdverseEffectForTheCompany.ToString(), "Adverse Effect For TheCompany"),
                new EnumDescription(2,enumType, IncidentType.FinancialViolations.ToString(), "Financial Violations"),
                new EnumDescription(3,enumType, IncidentType.SuspectedCrime.ToString(), "Suspected Crime")
            });
        }
    }
}

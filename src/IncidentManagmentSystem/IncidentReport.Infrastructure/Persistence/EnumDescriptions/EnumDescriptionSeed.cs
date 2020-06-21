using IncidentReport.Infrastructure.Persistence.EnumDescriptions.IncidentTypes;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Persistence.EnumDescriptions
{
    public static class EnumDescriptionSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            IncidentTypeSeed.Seed(modelBuilder);
        }
    }
}

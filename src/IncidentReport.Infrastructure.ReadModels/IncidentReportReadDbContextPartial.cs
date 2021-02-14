using Microsoft.EntityFrameworkCore;

namespace IncidentReport.ReadModels
{
    public partial class IncidentReportReadDbContext : DbContext
    {
        public IncidentReportReadDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

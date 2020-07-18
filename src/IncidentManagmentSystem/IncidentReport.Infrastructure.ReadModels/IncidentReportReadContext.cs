using System.Linq;
using IncidentReport.ReadModels.Contract;
using IncidentReport.ReadModels.Models;

namespace IncidentReport.ReadModels
{
    internal class IncidentReportReadContext : IIncidentReportReadContext
    {
        private readonly IncidentReportReadDbContext _incidentReportReadDbContext;

        public IQueryable<DraftApplication> DraftApplications => this._incidentReportReadDbContext.DraftApplication.AsQueryable();

        public IncidentReportReadContext(IncidentReportReadDbContext incidentReportReadDbContext)
        {
            this._incidentReportReadDbContext = incidentReportReadDbContext;
        }
    }
}

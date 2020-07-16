using System.Linq;
using IncidentReport.ReadModels.Models;

namespace IncidentReport.ReadModels
{
    public interface IIncidentReportReadContext
    {
        IQueryable<DraftApplication> DraftApplications { get; }
    }
}

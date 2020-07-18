using System.Linq;
using IncidentReport.ReadModels.Models;

namespace IncidentReport.ReadModels.Contract
{
    public interface IIncidentReportReadContext
    {
        IQueryable<DraftApplication> DraftApplications { get; }
    }
}

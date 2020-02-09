using System;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Infrastructure.Configuration
{
    public class IncidentReportStartupConfiguration
    {
        public Action<DbContextOptionsBuilder> DbContextOptionsBuilderAction { get; }
    }
}

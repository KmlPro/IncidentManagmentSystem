using System;
using System.Globalization;
using System.Text;
using BuildingBlocks.Domain.Abstract;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ApplicationNumber : ValueObject
    {
        public string Value { get; }

        public ApplicationNumber(DateTime postDate, IncidentType incidentType)
        {
            this.Value = this.Build(postDate, incidentType);
        }

        private string Build(DateTime dateCreated, IncidentType incidentType)
        {
            var sb = new StringBuilder();
            sb.Append(dateCreated.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo));
            sb.Append("_");
            sb.Append(incidentType.ToString());
            sb.Append("_");
            sb.Append(dateCreated.Millisecond);

            return sb.ToString();
        }
    }
}

using System;
using System.Globalization;
using System.Text;
using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.ValueObjects
{
    public class ApplicationNumber : ValueObject
    {
        public ApplicationNumber(DateTime postDate, IncidentType incidentType)
        {
            if (incidentType == null)
            {
                throw new ArgumentNullException(nameof(incidentType));
            }

            this.Value = this.Build(postDate, incidentType);
        }

        public string Value { get; }

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

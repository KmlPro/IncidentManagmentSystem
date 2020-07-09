using System;

namespace IncidentReport.Infrastructure.PublicDomain
{
    public class QueryNotFoundException : Exception
    {
        public QueryNotFoundException(string message) : base(message)
        {
        }
    }
}

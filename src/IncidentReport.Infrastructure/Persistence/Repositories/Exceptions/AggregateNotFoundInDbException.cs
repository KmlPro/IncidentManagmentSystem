using System;

namespace IncidentReport.Infrastructure.Persistence.Repositories.Exceptions
{
    public class AggregateNotFoundInDbException : Exception
    {
        public AggregateNotFoundInDbException(string aggregateName, Guid id) : base($"Aggregate {aggregateName} with id {id} not found")
        {
        }
    }
}

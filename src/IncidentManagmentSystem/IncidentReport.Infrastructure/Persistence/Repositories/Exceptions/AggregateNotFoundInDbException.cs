using System;

namespace IncidentReport.Infrastructure.Persistence.Repositories.Exceptions
{
    //kbytner 05.08.2020 - to do complete exception
    public class AggregateNotFoundInDbException : Exception
    {
        public AggregateNotFoundInDbException(string aggregateName, Guid id) : base()
        {
        }
    }
}

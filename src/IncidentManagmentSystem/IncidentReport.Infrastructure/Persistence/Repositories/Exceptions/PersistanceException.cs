using System;

namespace IncidentReport.Infrastructure.Persistence.Repositories.Exceptions
{
    //kbytner 05.08.2020 - to do complete exception
    public class PersistanceException : Exception
    {
        public PersistanceException(Exception exception): base(null, exception)
        {
        }
    }
}

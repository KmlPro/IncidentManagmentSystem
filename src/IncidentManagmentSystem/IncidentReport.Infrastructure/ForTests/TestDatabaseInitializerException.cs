using System;

namespace IncidentReport.Infrastructure.ForTests
{
    public class TestDatabaseInitializerException : Exception
    {
        public TestDatabaseInitializerException(string message) : base(message)
        {
        }

        public TestDatabaseInitializerException()
        {
        }

        public TestDatabaseInitializerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

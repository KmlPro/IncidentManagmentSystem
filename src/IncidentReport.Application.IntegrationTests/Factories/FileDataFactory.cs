using System;
using System.Text;
using IncidentReport.Application.Files;

namespace IncidentReport.Application.IntegrationTests.Factories
{
    public static class FileDataFactory
    {
        public static FileData Create()
        {
            var fileName = $"{Guid.NewGuid().ToString()}.txt";
            return Create(fileName);
        }

        public static FileData Create(string fileName)
        {
            return new FileData(fileName, Encoding.UTF8.GetBytes(fileName));
        }
    }
}

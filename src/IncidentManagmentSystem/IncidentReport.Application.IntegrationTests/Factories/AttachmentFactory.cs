using System;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.IntegrationTests.Factories
{
    public static class AttachmentFactory
    {
        public static Attachment Create()
        {
            var fileName = $"{Guid.NewGuid().ToString()}.txt";
            return new Attachment(new FileInfo(fileName), new StorageId(Guid.NewGuid()));
        }
    }
}

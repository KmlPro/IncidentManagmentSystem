using System;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.ValueObjects;

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

using System;
using System.Collections.Generic;
using IncidentReport.Domain.Entities.Attachments;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.DraftApplications.Attachments
{
    public class TestFixture
    {
        public List<Attachment> CreateAttachments(int numberOfAttachments)
        {
            var attachments = new List<Attachment>();

            for (var i = 0; i < numberOfAttachments; i++)
            {
                attachments.Add(new Attachment(new FileInfo("testFile.pdf"), new StorageId(Guid.NewGuid())));
            }

            return attachments;
        }
    }
}

using System;
using System.Collections.Generic;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Attachments
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

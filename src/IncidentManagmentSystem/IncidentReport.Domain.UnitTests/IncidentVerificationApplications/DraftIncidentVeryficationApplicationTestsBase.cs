using System;
using System.Collections.Generic;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    public class DraftIncidentVeryficationApplicationTestsBase : TestBase
    {
        public IEnumerable<IncidentVerificationApplicationAttachment> CreateAttachments(int numberOfAttachments)
        {
            var attachments = new List<IncidentVerificationApplicationAttachment>();

            for (var i = 0; i < numberOfAttachments; i++)
            {
                attachments.Add(new IncidentVerificationApplicationAttachment(new FileInfo("testFile.pdf"), new StorageId(Guid.NewGuid())));
            }

            return attachments;
        }
    }
}

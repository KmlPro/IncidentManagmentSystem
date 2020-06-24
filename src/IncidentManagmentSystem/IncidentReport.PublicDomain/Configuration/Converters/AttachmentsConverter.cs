using System.Collections.Generic;
using AutoMapper;
using IncidentReport.Domain.IncidentVerificationApplications;

namespace IncidentReport.PublicDomain.Configuration.Converters
{
    public class AttachmentsConverter : ITypeConverter<List<Attachment>, List<AttachmentDto>>
    {
        public List<AttachmentDto> Convert(List<Attachment> source, List<AttachmentDto> destination, ResolutionContext context)
        {
            var attachments = new List<AttachmentDto>();
            if (source != null)
            {
                foreach (var attachment in source)
                {
                    attachments.Add(new AttachmentDto(attachment.Id.Value, attachment.FileInfo.FileName, attachment.StorageId.Value));
                }
            }

            return attachments;
        }
    }
}

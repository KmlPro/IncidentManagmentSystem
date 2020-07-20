using AutoMapper;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.ReadModels.Dtos.Attachments
{
    public class AttachmentProfile : Profile
    {
        public AttachmentProfile()
        {
            this.CreateMap<Attachment, AttachmentDto>();
        }
    }
}

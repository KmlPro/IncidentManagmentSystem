using System;
using System.Collections.Generic;
using AutoMapper;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.PublicDomain.Configuration;
using IncidentReport.PublicDomain.Configuration.Converters;

namespace IncidentReport.PublicDomain.DraftApplications
{
    public class DraftApplicationDto : IMapFrom<DraftApplication>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IncidentType { get; set; }
        public List<Guid> SuspiciousEmployees { get; set; }
        public Guid ApplicantId { get; set; }
        public List<AttachmentDto> Attachments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<List<Attachment>, List<AttachmentDto>>().ConvertUsing(new AttachmentsConverter());

            profile.CreateMap<DraftApplication, DraftApplicationDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id.Value))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.ContentOfApplication.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.ContentOfApplication.Description))
                .ForMember(d => d.ApplicantId, opt => opt.MapFrom(s => s.ApplicantId.Value));
        }
    }
}

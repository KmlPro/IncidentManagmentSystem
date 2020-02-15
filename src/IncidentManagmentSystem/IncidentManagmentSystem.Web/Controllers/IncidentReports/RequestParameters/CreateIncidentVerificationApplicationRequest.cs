using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IncidentManagmentSystem.Web.Configuration.Mappings;
using IncidentManagmentSystem.Web.Files;
using IncidentReport.Application.Files;
using IncidentReport.Application.IncidentVerificationApplications.CreateIncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.AspNetCore.Http;

namespace IncidentManagmentSystem.Web.Controllers.IncidentReports.RequestParameters
{
    public class CreateIncidentVerificationApplicationRequest : IMapTo<CreateIncidentVerificationApplicationCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IncidentType IncidentType { get; set; }
        public IEnumerable<Guid> SuspiciousEmployees { get; set; }
        public List<IFormFile> Attachments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateIncidentVerificationApplicationRequest, CreateIncidentVerificationApplicationCommand>()
                .ForMember(d => d.Attachments, opt => opt.MapFrom(s => s.Attachments.Select(x => new FileData(x.FileName, x.GetBytes().Result))));
        }
    }
}

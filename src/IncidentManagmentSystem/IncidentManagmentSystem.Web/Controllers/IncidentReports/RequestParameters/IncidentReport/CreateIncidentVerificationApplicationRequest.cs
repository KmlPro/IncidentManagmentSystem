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

namespace IncidentManagmentSystem.Web.Controllers.IncidentReports.RequestParameters.IncidentReport
{
    public class CreateIncidentVerificationApplicationRequest : IMapTo<CreateIncidentVerificationApplicationCommand>
    {
        public string Title { get; }
        public string Description { get; }
        public IncidentType IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<IFormFile> Attachments { get; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateIncidentVerificationApplicationRequest, CreateIncidentVerificationApplicationCommand>()
                .ForMember(d => d.Attachments, opt => opt.MapFrom(s => s.Attachments.Select(x => new FileData(x.FileName, x.GetBytes().Result))));
        }
    }
}

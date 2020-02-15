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
        public string Title { get; }
        public string Description { get; }
        public IncidentType IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<IFormFile> Attachments { get; }

        public CreateIncidentVerificationApplicationRequest()
        {
            //just for automapper
        }

        public CreateIncidentVerificationApplicationRequest(string title, string description, IncidentType incidentType, IEnumerable<Guid> suspiciousEmployees, List<IFormFile> attachments)
        {
            this.Title = title;
            this.Description = description;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.Attachments = this.Attachments;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateIncidentVerificationApplicationRequest, CreateIncidentVerificationApplicationCommand>()
                .ForMember(d => d.Attachments, opt => opt.MapFrom(s => s.Attachments.Select(x => new FileData(x.FileName, x.GetBytes().Result))));
        }
    }
}

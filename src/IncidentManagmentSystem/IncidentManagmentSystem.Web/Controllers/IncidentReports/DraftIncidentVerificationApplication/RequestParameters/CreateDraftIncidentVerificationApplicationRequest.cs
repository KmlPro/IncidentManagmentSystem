using System;
using System.Collections.Generic;
using AutoMapper;
using IncidentManagmentSystem.Web.Configuration.Mappings;
using IncidentManagmentSystem.Web.Files;
using IncidentReport.Application.Files;
using IncidentReport.Application.IncidentVerificationApplications.CreateDraftIncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.AspNetCore.Http;

namespace IncidentManagmentSystem.Web.Controllers.IncidentReports.DraftIncidentVerificationApplication.RequestParameters
{
    public class CreateDraftIncidentVerificationApplicationRequest : IMapTo<CreateDraftIncidentVerificationApplicationCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IncidentType IncidentType { get; set; }
        public IEnumerable<Guid> SuspiciousEmployees { get; set; }
        public List<IFormFile> Attachments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<List<IFormFile>, List<FileData>>().ConvertUsing(new IFormFileTypeConverter());
            profile.CreateMap<CreateDraftIncidentVerificationApplicationRequest, CreateDraftIncidentVerificationApplicationCommand>();
        }
    }
}

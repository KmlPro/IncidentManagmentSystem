using System;
using System.Collections.Generic;
using AutoMapper;
using IncidentManagementSystem.Web.Configuration.Mappings;
using IncidentManagementSystem.Web.Configuration.Mappings.Converters;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.Files;
using Microsoft.AspNetCore.Http;

namespace IncidentManagementSystem.Web.IncidentReports.UseCases.CreateDraftApplications
{
    public class CreateDraftApplicationRequest : IMapTo<CreateDraftApplicationInput>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string IncidentType { get; set; }

        public IEnumerable<Guid> SuspiciousEmployees { get; set; }

        public List<IFormFile> Attachments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<List<IFormFile>, List<FileData>>().ConvertUsing(new IFormFileTypeConverter());
            profile.CreateMap<CreateDraftApplicationRequest, CreateDraftApplicationInput>();
        }
    }
}

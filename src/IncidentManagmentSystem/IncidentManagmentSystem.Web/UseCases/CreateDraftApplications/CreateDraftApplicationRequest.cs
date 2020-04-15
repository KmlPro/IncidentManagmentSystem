using System;
using System.Collections.Generic;
using AutoMapper;
using IncidentManagmentSystem.Web.Configuration.Mappings;
using IncidentManagmentSystem.Web.Files;
using IncidentReport.Application.Boundaries.CreateDraftApplications;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.AspNetCore.Http;

namespace IncidentManagmentSystem.Web.UseCases.CreateDraftApplications
{
    public class CreateDraftApplicationRequest : IMapTo<CreateDraftApplicationInput>
    {
        public string Title { get; }
        public string Description { get; }
        public IncidentType IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<IFormFile> Attachments { get; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<List<IFormFile>, List<FileData>>().ConvertUsing(new IFormFileTypeConverter());
            profile.CreateMap<CreateDraftApplicationRequest, CreateDraftApplicationInput>();
        }
    }
}

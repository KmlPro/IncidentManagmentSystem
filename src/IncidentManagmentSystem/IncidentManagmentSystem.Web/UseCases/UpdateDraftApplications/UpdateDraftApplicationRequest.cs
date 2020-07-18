using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using IncidentManagmentSystem.Web.Configuration.Mappings;
using IncidentManagmentSystem.Web.Configuration.Mappings.Converters;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Files;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace IncidentManagmentSystem.Web.UseCases.UpdateDraftApplications
{
    public class UpdateDraftApplicationRequest : IMapTo<UpdateDraftApplicationInput>
    {
        [MapTo(nameof(UpdateDraftApplicationInput.DraftApplicationId))]
        [Required]
        public Guid Id { get; set; }

        [MinLength(10)]
        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(10)]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string IncidentType { get; set; }

        public IEnumerable<Guid> SuspiciousEmployees { get; set; }

        public List<IFormFile> AddedAttachments { get; set; }

        public List<Guid> DeletedAttachments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<List<IFormFile>, List<FileData>>().ConvertUsing(new IFormFileTypeConverter());
            profile.CreateMap<UpdateDraftApplicationRequest, UpdateDraftApplicationInput>();
        }
    }
}

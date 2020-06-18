using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using IncidentManagmentSystem.Web.Configuration.Mappings;
using IncidentManagmentSystem.Web.Configuration.Mappings.Converters;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Files;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
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

        public IncidentType? IncidentType { get; set; }

        public IEnumerable<Guid> SuspiciousEmployees { get; set; }

        public List<FileData> AddedAttachments { get; set; }

        public List<Guid> DeletedAttachments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<List<IFormFile>, List<FileData>>().ConvertUsing(new IFormFileTypeConverter());
            profile.CreateMap<UpdateDraftApplicationRequest, UpdateDraftApplicationInput>();
        }
    }
}

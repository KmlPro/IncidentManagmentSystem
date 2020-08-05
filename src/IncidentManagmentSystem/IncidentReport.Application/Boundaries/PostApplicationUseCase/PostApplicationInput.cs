using System;
using System.Collections.Generic;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Application.Files;

namespace IncidentReport.Application.Boundaries.PostApplicationUseCase
{
    public class PostApplicationInput : IUseCaseInput<IOutputPort>
    {
        public PostApplicationInput(string title, string description, string incidentType,
            IEnumerable<Guid> suspiciousEmployees, List<FileData> attachments)
        {
            this.Title = title;
            this.Description = description;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.Attachments = attachments;
        }

        public string Title { get; }
        public string Description { get; }
        public string IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<FileData> Attachments { get; }
    }
}

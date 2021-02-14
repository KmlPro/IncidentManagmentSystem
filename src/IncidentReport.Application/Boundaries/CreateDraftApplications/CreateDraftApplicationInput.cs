using System;
using System.Collections.Generic;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Application.Files;

namespace IncidentReport.Application.Boundaries.CreateDraftApplications
{
    public class CreateDraftApplicationInput : IUseCaseInput<IOutputPort>
    {
        public CreateDraftApplicationInput(string title, string content, string incidentType,
            IEnumerable<Guid> suspiciousEmployees, List<FileData> attachments)
        {
            this.Title = title;
            this.Content = content;
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees;
            this.Attachments = attachments;
        }

        public string Title { get; }
        public string Content { get; }
        public string IncidentType { get; }
        public IEnumerable<Guid> SuspiciousEmployees { get; }
        public List<FileData> Attachments { get; }
    }
}

// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using BuildingBlocks.Application;
// using BuildingBlocks.Application.Abstract;
// using BuildingBlocks.Domain.Abstract;
// using IncidentReport.Application.Boundaries.PostApplicationUseCase;
// using IncidentReport.Application.Files;
// using IncidentReport.Domain.Employees.ValueObjects;
// using IncidentReport.Domain.IncidentVerificationApplications.Applications;
// using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
// using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
//
// namespace IncidentReport.Application.UseCases
// {
//     public class PostApplicationUseCase : IUseCase
//     {
//         private readonly ICurrentUserContext _applicantContext;
//         private readonly IFileStorageService _fileStorageService;
//         private readonly IApplicationRepository _applicationRepository;
//         private readonly IOutputPort _outputPort;
//
//         public PostApplicationUseCase(IApplicationRepository applicationRepository,
//             ICurrentUserContext userContext,
//             IFileStorageService fileStorageService,
//             IOutputPort outputPort)
//         {
//             this._applicationRepository = applicationRepository;
//             this._applicantContext = userContext;
//             this._fileStorageService = fileStorageService;
//             this._outputPort = outputPort;
//         }
//         public Task<IOutputPort> Handle(PostApplicationInput request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var draftApplication = this.CreateDraft(input);
//
//                 if (this.IfAddedAttachmentsExists(input))
//                 {
//                     var files = await this.UploadFilesToStorage(input);
//                     this.AddUploadedFilesAsAttachments(draftApplication, files);
//                 }
//
//                 await this._incidentReportContext.DraftApplication.AddAsync(draftApplication,
//                     cancellationToken);
//
//                 this.BuildOutput(draftApplication);
//             }
//             catch (BusinessRuleValidationException ex)
//             {
//                 this._outputPort.WriteBusinessRuleError(ex.ToString());
//             }
//             catch (ApplicationLayerException ex)
//             {
//                 this._outputPort.WriteBusinessRuleError(ex.ToString());
//             }
//
//             return this._outputPort;
//         }
//
//         private bool IfAddedAttachmentsExists(CreateDraftApplicationInput request)
//         {
//             return request.Attachments != null && request.Attachments.Any();
//         }
//
//         private CreatedApplication CreateDraft(PostApplicationInput request)
//         {
//             return Domain.IncidentVerificationApplications.Applications.Application.Create(
//                 new ContentOfApplication(request.Title, request.Description),
//                 new IncidentType(request.IncidentType),
//                 new EmployeeId(this._applicantContext.UserId),
//                 new List<EmployeeId>(
//                     request.SuspiciousEmployees.Select(x => new EmployeeId(x)))
//             );
//         }
//     }
// }

using AutoMapper;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.ReadModels.Dtos.IncidentApplications
{
    public class IncidentApplicationProfile : Profile
    {
        public IncidentApplicationProfile()
        {
            this.CreateMap<IncidentApplication, IncidentApplicationDto>().ForMember(
                dest => dest.IncidentType,
                opt => opt.MapFrom(src => src.IncidentType)
            ).ForMember(
                dest => dest.SuspiciousEmployee,
                opt => opt.MapFrom(src => src.IncidentApplicationSuspiciousEmployees)
            ).ForMember(
                dest => dest.ApplicationState,
                opt => opt.MapFrom(src => src.ApplicationStateValue)
            );
        }
    }
}

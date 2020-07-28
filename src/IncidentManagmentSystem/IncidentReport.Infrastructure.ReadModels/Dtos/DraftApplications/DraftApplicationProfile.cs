using AutoMapper;
using IncidentReport.ReadModels.DbEntities;
using IncidentReport.ReadModels.Dtos.Employees;

namespace IncidentReport.ReadModels.Dtos.DraftApplications
{
    public class DraftApplicationProfile : Profile
    {
        public DraftApplicationProfile()
        {
            this.CreateMap<DraftApplication, DraftApplicationDto>().
                ForMember(
                dest => dest.IncidentType,
                opt => opt.MapFrom(src => src.IncidentTypeValue)
            );

        }
    }
}

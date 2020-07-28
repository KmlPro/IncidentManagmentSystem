using AutoMapper;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.ReadModels.Dtos.DraftApplications
{
    public class DraftApplicationProfile : Profile
    {
        public DraftApplicationProfile()
        {
            //kbytner 29.07.2020 - to do mapping for suspiciousEmployee and Attachments
            this.CreateMap<DraftApplication, DraftApplicationDto>().ForMember(
                dest => dest.IncidentType,
                opt => opt.MapFrom(src => src.IncidentTypeValue)
            );
        }
    }
}

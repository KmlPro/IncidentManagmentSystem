using AutoMapper;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.ReadModels.Dtos.DraftApplications
{
    public class DraftApplicationProfile : Profile
    {
        public DraftApplicationProfile()
        {
            this.CreateMap<DraftApplication, DraftApplicationDto>();
        }
    }
}

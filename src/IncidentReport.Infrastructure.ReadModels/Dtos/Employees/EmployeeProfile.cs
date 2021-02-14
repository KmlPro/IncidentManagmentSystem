using AutoMapper;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.ReadModels.Dtos.Employees
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            this.CreateMap<Employee, EmployeeDto>();
            this.CreateMap<DraftApplicationSuspiciousEmployee, EmployeeDto>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Employee.Id)).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Employee.Name)).ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Employee.Surname));
            this.CreateMap<IncidentApplicationSuspiciousEmployee, EmployeeDto>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Employee.Id)).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Employee.Name)).ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Employee.Surname));

        }
    }
}

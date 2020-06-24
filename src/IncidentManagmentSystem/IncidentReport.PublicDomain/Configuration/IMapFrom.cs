using AutoMapper;

namespace IncidentReport.PublicDomain.Configuration
{
    // ref https://github.com/jasontaylordev/CleanArchitecture
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}

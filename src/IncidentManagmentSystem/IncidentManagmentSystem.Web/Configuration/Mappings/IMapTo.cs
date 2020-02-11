using AutoMapper;

namespace IncidentManagmentSystem.Web.Configuration.Mappings
{
    // ref https://github.com/jasontaylordev/CleanArchitecture
    public interface IMapTo<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), this.GetType());
        }
    }
}

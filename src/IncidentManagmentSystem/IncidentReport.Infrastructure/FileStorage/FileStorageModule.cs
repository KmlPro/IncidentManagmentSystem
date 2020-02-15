using Autofac;
using IncidentReport.Application.Files;

namespace IncidentReport.Infrastructure.FileStorage
{
    internal class FileStorageModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileStorageService>().As<IFileStorageService>();
        }
    }
}

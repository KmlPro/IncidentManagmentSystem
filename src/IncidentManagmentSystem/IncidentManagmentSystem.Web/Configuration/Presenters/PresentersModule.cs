using Autofac;
using IncidentManagmentSystem.Web.UseCases.CreateDraftApplications;
using IncidentReport.Application.Boundaries.CreateDraftApplications;

namespace IncidentManagmentSystem.Web.Configuration.Presenters
{
    internal class PresentersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IOutputPort>().As<CreateDraftApplicationPresenter>().InstancePerLifetimeScope();
        }
    }
}


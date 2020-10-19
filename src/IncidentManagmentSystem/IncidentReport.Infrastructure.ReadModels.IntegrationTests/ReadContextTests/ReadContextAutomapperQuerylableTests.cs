using System.Linq;
using Autofac;
using IncidentReport.ReadModels.Contract;
using NUnit.Framework;

namespace IncidentReport.Infrastructure.ReadModels.IntegrationTests.ReadContextTests
{
    [Category(CategoryTitle.Title + " AutomapperMapTo")]
    public class ReadContextAutoMapperQuerylableTests
    {
        private TestContainer _testContainer;
        private ReadContextAutoMapperQuerylableTestFixture _testFixture;

        public ReadContextAutoMapperQuerylableTests()
        {
            this._testContainer = new TestContainer();
            this._testFixture = new ReadContextAutoMapperQuerylableTestFixture();
        }

        [Test]
        public void MapDraftApplicationEntity_To_MapDraftApplicationDto_MapEntireEntity_TakeOne_MappedSuccessfully()
        {
            using (var container = this._testContainer.BeginLifetimeScope())
            {
                this._testFixture.AddDraftApplicationWithEmployeesInDatabase(container);
                var readContext = container.Resolve<IIncidentReportReadContext>();
                var data = readContext.DraftApplications.Take(1).ToList();
                Assert.True(data.Count == 1);
            }
        }

        [Test]
        public void MapDraftApplicationEntity_To_MapDraftApplicationDto_SelectOnlyOneColumn()
        {
            using (var container = this._testContainer.BeginLifetimeScope())
            {
                this._testFixture.AddDraftApplicationWithEmployeesInDatabase(container);
                var readContext = container.Resolve<IIncidentReportReadContext>();
                var data = readContext.DraftApplications.Select(x=> x.IncidentType).ToList();
                Assert.IsNotEmpty(data.First());
            }
        }
    }
}

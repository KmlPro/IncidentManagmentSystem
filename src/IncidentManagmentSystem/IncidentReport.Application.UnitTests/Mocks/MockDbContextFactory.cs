using System.Collections.Generic;
using System.Linq;
using System.Threading;
using IncidentReport.Application.Common;
using IncidentReport.Domain.IncidentVerificationApplications;
using Microsoft.EntityFrameworkCore;
using Moq;

//<summmary>
// Mocking DbSets - inspiration - https://www.jankowskimichal.pl/2016/02/mockowanie-typow-dbcontext-oraz-dbset-z-wykorzystaniem-moq/
// Mocking DbSets - https://stackoverflow.com/questions/31349351/how-to-add-an-item-to-a-mock-dbset-using-moq
// AddAsync - https://stackoverflow.com/questions/49142556/how-do-i-mock-addasync
//</summary>

namespace IncidentReport.Application.UnitTests.Mocks
{
    internal class MockDbContextFactory
    {
        public IIncidentReportDbContext IncidentReportDbContext { get; set; }

        private readonly List<DraftIncidentVerificationApplication> _draftIncidentVerificationApplication;

        public MockDbContextFactory()
        {
            this._draftIncidentVerificationApplication = new List<DraftIncidentVerificationApplication>();
            this.IncidentReportDbContext = this.CreateDbContext();
        }

        public IIncidentReportDbContext CreateDbContext()
        {
            var incidentReportDbContext = new Mock<IIncidentReportDbContext>();

            var draftIncidentVerificationApplication = this.GetMockDbSet(this._draftIncidentVerificationApplication);

            incidentReportDbContext.Setup(x => x.DraftIncidentVerificationApplication).Returns(draftIncidentVerificationApplication.Object);

            return incidentReportDbContext.Object;
        }

        private Mock<DbSet<T>> GetMockDbSet<T>(ICollection<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());
            mockSet.Setup(m => m.AddAsync(It.IsAny<T>(), It.IsAny<CancellationToken>())).Callback(action: (T model, CancellationToken token) => entities.Add(model));
            return mockSet;
        }
    }
}

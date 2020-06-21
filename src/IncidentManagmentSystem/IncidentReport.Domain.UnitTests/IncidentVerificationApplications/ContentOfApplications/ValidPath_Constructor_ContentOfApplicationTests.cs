using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.ContentOfApplications
{
    [TestFixture]
    [Category(CategoryTitle.Title + " ContentOfApplication")]
    public class ValidPath_Constructor_ContentOfApplicationTests : TestBase
    {
        [Test]
        public void AllFieldsAreValid_CreatedSuccessfully()
        {
            var contentOfApplicationBuilder = new ContentOfApplicationBuilder()
                .SetTitle(FakeData.Alpha(11))
                .SetDescription(FakeData.Alpha(100));

            var contentOfApplication = contentOfApplicationBuilder.Build();
            Assert.NotNull(contentOfApplication);
        }
    }
}

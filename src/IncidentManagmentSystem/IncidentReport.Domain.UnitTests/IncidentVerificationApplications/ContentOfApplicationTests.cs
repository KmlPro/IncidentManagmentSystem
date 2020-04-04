using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications
{
    [TestFixture]
    public class ContentOfApplicationTests : TestBase
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

        [TestCase(1)]
        [TestCase(101)]
        public void TitleRuleViolated_NotCreated(int titleLength)
        {
            var contentOfApplicationBuilder = new ContentOfApplicationBuilder()
                .SetTitle(FakeData.Alpha(titleLength))
                .SetDescription(FakeData.Alpha(20));

            AssertBrokenRule<ApplicationTitleLenghtRule>(() =>
            {
                var contentOfApplication = contentOfApplicationBuilder.Build();
            });
        }

        [TestCase(1)]
        [TestCase(1001)]
        public void DescriptionRuleViolated_NotCreated(int descriptionLength)
        {
            var contentOfApplicationBuilder = new ContentOfApplicationBuilder()
                .SetTitle(FakeData.Alpha(11))
                .SetDescription(FakeData.Alpha(descriptionLength));

            AssertBrokenRule<ApplicationDescriptionLengthRule>(() =>
            {
                var contentOfApplication = contentOfApplicationBuilder.Build();
            });
        }
    }
}

using System;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.ContentOfApplications
{
    [TestFixture]
    [Category(CategoryTitle.Title + " ContentOfApplication")]
    public class RuleCheck_ContentOfApplicationTests : TestBase
    {
        [TestCase(1)]
        [TestCase(101)]
        public void TitleRuleViolated_NotCreated(int titleLength)
        {
            var contentOfApplicationBuilder = new ContentOfApplicationBuilder()
                .SetTitle(FakeData.Alpha(titleLength))
                .SetDescription(FakeData.Alpha(20));

            AssertException<ArgumentOutOfRangeException>(() =>
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

            AssertException<ArgumentOutOfRangeException>(() =>
            {
                var contentOfApplication = contentOfApplicationBuilder.Build();
            });
        }
    }
}

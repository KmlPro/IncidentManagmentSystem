using System;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using NUnit.Framework;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Contents
{
    [Category(CategoryTitle.Title + " Content")]
    public class ContentTests : TestBase
    {
        [Test]
        public void TryCreate_Has10Chars_Created()
        {
            var content = new Content(FakeData.Alpha(10));
            Assert.NotNull(content);
        }

        [Test]
        public void TryCreate_HasLessThan10Chars_NotCreated()
        {
            AssertException<ArgumentException>(()  =>
            {
                new Content(FakeData.Alpha(9));
            });
        }

        [Test]
        public void TryCreate_HasMoreThan1000Chars_NotCreated()
        {
            AssertException<ArgumentException>(()  =>
            {
                new Content(FakeData.Alpha(1001));
            });
        }
    }
}

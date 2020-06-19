using System.Collections.Generic;
using IncidentReport.Application.Files.Exceptions;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.CreateDraftApplication
{
    [Category(CategoryTitle.Title + " CreateDraftApplicationUseCase")]
    public class RuleCheck_CreateDraftApplicationTests : BaseTest
    {
        private readonly TestFixture _testFixture;

        public RuleCheck_CreateDraftApplicationTests()
        {
            this._testFixture = new TestFixture();
        }

        [Test]
        public void AttachmentsWithUnallowedExtension_DraftNotCreated()
        {
            AssertApplicationLayerException<UnallowedFileExtensionException>(() =>
                this._testFixture.CreateUseCaseWithRequiredFields(new List<string> { "testFile.exe" }));
        }

        [Test]
        public void AttachmentsWithoutExtension_DraftNotCreated()
        {
            AssertApplicationLayerException<FileExtensionNotRecognizedException>(() =>
                this._testFixture.CreateUseCaseWithRequiredFields(new List<string> { "testFile" }));
        }
    }
}

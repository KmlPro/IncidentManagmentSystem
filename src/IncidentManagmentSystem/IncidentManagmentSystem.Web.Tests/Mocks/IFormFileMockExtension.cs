using System.IO;
using IncidentManagmentSystem.Web.Tests.Mocks.JsonMoq;
using Microsoft.AspNetCore.Http;
using Moq;

namespace IncidentManagmentSystem.Web.Tests.Mocks
{
    // https://stackoverflow.com/questions/37628743/instantiating-an-iformfile-from-a-physical-file
    internal static class IFormFileMockExtension
    {
        public static IFormFile AsMockIFormFile(this FileInfo physicalFile)
        {
            var fileMock = new Mock<IFormFile>();
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(physicalFile.OpenRead());
            writer.Flush();
            ms.Position = 0;
            var fileName = physicalFile.Name;
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);
            fileMock.Setup(m => m.OpenReadStream()).Returns(ms);
            fileMock.Setup(m => m.ContentDisposition).Returns(string.Format("inline; filename={0}", fileName));

            fileMock.RegisterForJsonSerialization();
            return fileMock.Object;
        }
    }
}

using BuildingBlocks.Application.Abstract;

namespace IncidentReport.Application.Files.Exceptions
{
    public class FileExtensionNotRecognizedException : ApplicationLayerException
    {
        private const string _errorMessage = "Extension not recognized";

        public FileExtensionNotRecognizedException() : base(_errorMessage)
        {
        }
    }
}

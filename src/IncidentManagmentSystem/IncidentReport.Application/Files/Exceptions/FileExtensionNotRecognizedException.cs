using BuildingBlocks.Application.Exceptions;

namespace IncidentReport.Application.Files.Exceptions
{
    public class FileExtensionNotRecognizedException : ApplicationLayerException
    {
        private static readonly string _errorMessage = Resources.FileExtensionNotRecognizedException;

        public FileExtensionNotRecognizedException() : base(_errorMessage)
        {
        }
    }
}

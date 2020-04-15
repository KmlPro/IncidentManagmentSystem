using BuildingBlocks.Application.Abstract;

namespace IncidentReport.Application.Files.Exceptions
{
    public class FileExtensionNotRecognizedException : ApplicationLayerException
    {
        private readonly static string _errorMessage = Resources.FileExtensionNotRecognizedException;

        public FileExtensionNotRecognizedException() : base(_errorMessage)
        {
        }
    }
}

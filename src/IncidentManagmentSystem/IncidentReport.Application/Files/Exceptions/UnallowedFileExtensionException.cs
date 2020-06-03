using BuildingBlocks.Application.Abstract;

namespace IncidentReport.Application.Files.Exceptions
{
    public class UnallowedFileExtensionException : ApplicationLayerException
    {
        private static readonly string _errorMessage = Resources.UnallowedFileExtensionException;

        public UnallowedFileExtensionException() : base(_errorMessage)
        {
        }
    }
}

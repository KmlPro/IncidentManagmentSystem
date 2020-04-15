using BuildingBlocks.Application.Abstract;

namespace IncidentReport.Application.Files.Exceptions
{
    public class UnallowedFileExtensionException : ApplicationLayerException
    {
        private readonly static string _errorMessage = Resources.UnallowedFileExtensionException;

        public UnallowedFileExtensionException() : base(_errorMessage)
        {
        }
    }
}

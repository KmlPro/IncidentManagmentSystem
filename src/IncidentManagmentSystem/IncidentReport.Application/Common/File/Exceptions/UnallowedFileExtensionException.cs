using BuildingBlocks.Application.Abstract;

namespace IncidentReport.Application.Common.File.Exceptions
{
    public class UnallowedFileExtensionException : ApplicationLayerException
    {
        private const string _errorMessage = "Unallowed file extension.";

        public UnallowedFileExtensionException() : base(_errorMessage)
        {
        }
    }
}

using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class FileInfo : ValueObject
    {
        public FileInfo(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; }
    }
}

using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class FileInfo : ValueObject
    {
        public string FileName { get; }
        public FileInfo(string fileName)
        {
            this.FileName = fileName;
        }
    }
}

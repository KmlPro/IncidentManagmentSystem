using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class FileData : ValueObject
    {
        public string FileName { get; }
        public string Extension { get; }

        public FileData(string fileName, string extension)
        {
            this.FileName = fileName;
            this.Extension = extension;
        }
    }
}

using BuildingBlocks.Domain.Abstract;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class FileInfo : ValueObject
    {
        public string FileName { get; }
        public string Extension { get; }

        public FileInfo(string fileName, string extension)
        {
            this.FileName = fileName;
            this.Extension = extension;
        }
    }
}

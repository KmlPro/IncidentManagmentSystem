using System.Collections.Generic;
using System.IO;
using System.Linq;
using IncidentReport.Application.Common.File.Exceptions;

namespace IncidentReport.Application.Common.File
{
    public class FileData
    {
        public string FileName { get; }
        public byte[] Content { get; }

        public FileData(string fileName, byte[] content)
        {
            this.CheckExtensions(fileName);

            this.FileName = fileName;
            this.Content = content;
        }

        private void CheckExtensions(string fileName)
        {
            var extension = Path.GetExtension(fileName).Replace(".", "");

            if (string.IsNullOrEmpty(extension))
            {
                throw new FileExtensionNotRecognizedException();
            }
            else if (!(this._allowedImagesExtensions.Any(x => x == extension) ||
                this._allowedExcelExtensions.Any(x => x == extension) ||
                this._allowedDocumentExtensions.Any(x => x == extension) ||
                this._allowedOtherExtensions.Any(x => x == extension)))
            {
                throw new UnallowedFileExtensionException();
            }
        }

        private readonly IEnumerable<string> _allowedImagesExtensions = new List<string>
        {
          "jpeg",
          "png",
          "jpg",
        };

        private readonly IEnumerable<string> _allowedExcelExtensions = new List<string>
        {
          "xls",
          "xlsx",
        };

        private readonly IEnumerable<string> _allowedDocumentExtensions = new List<string>
        {
          "doc",
          "docx",
          "odt"
        };

        private readonly IEnumerable<string> _allowedOtherExtensions = new List<string>
        {
          "pdf",
          "xlsx",
        };
    }
}

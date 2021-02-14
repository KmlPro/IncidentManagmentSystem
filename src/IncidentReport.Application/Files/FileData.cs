using System;
using System.Collections.Generic;
using System.IO;

namespace IncidentReport.Application.Files
{
    //kbytner 12.11.2020 - validation should be moved to FluentValidatior
    public class FileData
    {
        private readonly IEnumerable<string> _allowedDocumentExtensions = new List<string> {"doc", "docx", "odt"};

        private readonly IEnumerable<string> _allowedExcelExtensions = new List<string> {"xls", "xlsx"};

        private readonly IEnumerable<string> _allowedImagesExtensions = new List<string> {"jpeg", "png", "jpg"};

        private readonly IEnumerable<string> _allowedOtherExtensions = new List<string> {"pdf", "xlsx", "txt"};

        public FileData(string fileName, byte[] content)
        {
            this.CheckExtensions(fileName);

            this.FileName = fileName;
            this.Content = content;
        }

        public string FileName { get; }
        public byte[] Content { get; }

        private void CheckExtensions(string fileName)
        {
            var extension = Path.GetExtension(fileName).Replace(".", "", StringComparison.Ordinal);

            // if (string.IsNullOrEmpty(extension))
            // {
            //     throw new FileExtensionNotRecognizedException();
            // }
            //
            // if (!(this._allowedImagesExtensions.Any(x => x == extension) ||
            //       this._allowedExcelExtensions.Any(x => x == extension) ||
            //       this._allowedDocumentExtensions.Any(x => x == extension) ||
            //       this._allowedOtherExtensions.Any(x => x == extension)))
            // {
            //     throw new UnallowedFileExtensionException();
            // }
        }
    }
}

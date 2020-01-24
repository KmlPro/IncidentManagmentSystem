using System.Collections.Generic;
using System.IO;

namespace IncidentReport.Application.Common.File
{
    //kbytner 25.01.2020 - to do, checkExtension and Exceptions
    public class FileData
    {
        public string FileName { get; }
        public byte[] Content { get; }

        public FileData(string fileName, byte[] content)
        {
            this.FileName = fileName;
            this.Content = content;
        }

        private void CheckExtensions(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
            {

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

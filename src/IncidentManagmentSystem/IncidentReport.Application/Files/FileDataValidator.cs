using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentValidation;

namespace IncidentReport.Application.Files
{
    public class FileDataValidator : AbstractValidator<FileData>
    {
        private readonly IEnumerable<string> _allowedDocumentExtensions = new List<string> {"doc", "docx", "odt"};

        private readonly IEnumerable<string> _allowedExcelExtensions = new List<string> {"xls", "xlsx"};

        private readonly IEnumerable<string> _allowedImagesExtensions = new List<string> {"jpeg", "png", "jpg"};

        private readonly IEnumerable<string> _allowedOtherExtensions = new List<string> {"pdf", "xlsx", "txt"};

        public FileDataValidator()
        {
            this.RuleFor(x => x).Transform(x => x.Content).NotNull();
            this.RuleFor(x => x).Transform(x => x.FileName).NotEmpty();

            this.RuleFor(x => x)
                .Transform(x=> this.GetExtension(x.FileName))
                .Must(extension =>
                {
                    if (!(this._allowedImagesExtensions.Any(x => x == extension) ||
                          this._allowedExcelExtensions.Any(x => x == extension) ||
                          this._allowedDocumentExtensions.Any(x => x == extension) ||
                          this._allowedOtherExtensions.Any(x => x == extension)))
                    {
                        return false;
                    }

                    return true;
                })
                .WithMessage("Not allowed file extension");
        }

        private string GetExtension(string fileName)
        {
            return Path.GetExtension(fileName).Replace(".", "", StringComparison.Ordinal);
        }
    }
}

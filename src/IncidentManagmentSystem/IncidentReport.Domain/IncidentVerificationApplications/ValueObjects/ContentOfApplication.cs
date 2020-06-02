using System;
using BuildingBlocks.Domain.Abstract;
using JetBrains.Annotations;

namespace IncidentReport.Domain.IncidentVerificationApplications.ValueObjects
{
    public class ContentOfApplication : ValueObject
    {
        private readonly int _minTitleLength = 10;
        private readonly int _maxTitleLength = 100;

        private readonly int _minDescriptionLength = 10;
        private readonly int _maxDescriptionLength = 1000;

        public string Title { get; }
        public string Description { get; }

        private ContentOfApplication()
        {

        }

        public ContentOfApplication([NotNull] string title, [NotNull] string description)
        {
            this.CheckTitleLength(title);
            this.CheckDescriptionLength(description);

            this.Title = title;
            this.Description = description;
        }

        private void CheckDescriptionLength(string description)
        {
            if (description.Length < this._minDescriptionLength)
            {
                throw new ArgumentOutOfRangeException(nameof(description), string.Format(Resources.ApplicationDescriptionTooShortException, this._minTitleLength));
            }
            else if (description.Length >= this._maxDescriptionLength)
            {
                throw new ArgumentOutOfRangeException(nameof(description), string.Format(Resources.ApplicationDescriptionTooLongException, this._minTitleLength));
            }
        }

        private void CheckTitleLength(string title)
        {      
            if (title.Length < this._minTitleLength)
            {
                throw new ArgumentOutOfRangeException(nameof(title), string.Format(Resources.ApplicationTitleTooShortException, this._minTitleLength));
            }
            else if (this.Title.Length >= this._maxTitleLength)
            {
                throw new ArgumentOutOfRangeException(nameof(title), string.Format(Resources.ApplicationTitleTooLongException, this._maxTitleLength));
            }
        }
    }
}

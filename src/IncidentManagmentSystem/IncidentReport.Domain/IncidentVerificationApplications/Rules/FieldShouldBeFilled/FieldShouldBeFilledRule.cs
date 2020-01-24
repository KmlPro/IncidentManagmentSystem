using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.FieldShouldBeFilled.Exceptions;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.FieldShouldBeFilled
{
    internal class FieldShouldBeFilledRule : IBusinessRule
    {
        private object Field { get; }

        private string FieldName { get; }

        public FieldShouldBeFilledRule(object field, string fieldName)
        {
            this.Field = field;
            this.FieldName = fieldName;
        }

        public void CheckIsBroken()
        {
            if (this.Field.GetType() == typeof(string) && string.IsNullOrEmpty(this.Field as string))
            {
                throw new FieldShouldBeFilledException(this, this.FieldName);
            }
            else if (this.Field == null)
            {
                throw new FieldShouldBeFilledException(this, this.FieldName);
            }
        }
    }
}

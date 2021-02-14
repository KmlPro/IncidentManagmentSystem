using System;
using FluentValidation;
using IncidentReport.Domain.ValueObjects;

namespace IncidentReport.Application.Common.Validators
{
    public class IncidentTypeValidator : AbstractValidator<IncidentTypeToValidate>
    {
        public IncidentTypeValidator() {
            RuleFor(x => x)
                .Must(incidenTypeToValidate =>
                {
                    try
                    {
                        var incidentType = new IncidentType(incidenTypeToValidate.IncidentType);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                })
                .WithMessage("Incorrect IncidentType value");
        }
    }

    public class IncidentTypeToValidate
    {
        public IncidentTypeToValidate(string incidentType)
        {
            this.IncidentType = incidentType;
        }

        public string IncidentType { get; }
    }
}

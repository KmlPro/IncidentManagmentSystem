using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace BuildingBlocks.Application.ValidationErrors
{
    public static class MapFluentValidatiorsExtensions
    {
        public static List<InvalidUseCaseInputValidationError> MapToInvaliInputErrors(this ValidationException ex)
        {
            var errors = new List<InvalidUseCaseInputValidationError>();
            if (ex != null && ex.Errors != null && ex.Errors.Any())
            {
                foreach (var fluentError in ex.Errors)
                {
                    errors.Add(new InvalidUseCaseInputValidationError(fluentError.PropertyName,fluentError.ErrorMessage, fluentError.AttemptedValue));
                }
            }

            return errors;
        }
    }
}

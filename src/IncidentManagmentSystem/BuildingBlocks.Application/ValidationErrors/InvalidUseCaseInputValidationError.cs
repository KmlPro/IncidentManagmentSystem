namespace BuildingBlocks.Application.ValidationErrors
{
    public class InvalidUseCaseInputValidationError
    {
        public InvalidUseCaseInputValidationError(string propertyName, string errorMessage, object attemptedValue)
        {
            this.PropertyName = propertyName;
            this.ErrorMessage = errorMessage;
            this.AttemptedValue = attemptedValue;
        }

        /// <summary>
        /// The name of the property.
        /// </summary>
        public string PropertyName { get;  }

        /// <summary>
        /// The error message
        /// </summary>
        public string ErrorMessage { get;  }

        /// <summary>
        /// The property value that caused the failure.
        /// </summary>
        public object AttemptedValue { get;  }
    }
}

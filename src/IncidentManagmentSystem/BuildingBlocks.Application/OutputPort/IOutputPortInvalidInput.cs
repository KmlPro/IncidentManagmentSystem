using System.Collections.Generic;
using BuildingBlocks.Application.ValidationErrors;

namespace BuildingBlocks.Application.OutputPort
{
    public interface IOutputPortInvalidInput
    {
        /// <summary>
        ///     Informs the resource was not found.
        /// </summary>
        void WriteInvalidInput(List<InvalidUseCaseInputValidationError> errors);
    }
}

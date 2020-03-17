using MediatR;

namespace BuildingBlocks.Application.Boundaries
{
    /// <typeparam name="TUseCaseInput">Any Input Message.</typeparam>
    public interface IUseCase<in TUseCaseInput> : IRequestHandler<TUseCaseInput> where TUseCaseInput : IUseCaseInput
    {
    }
}

using MediatR;

namespace BuildingBlocks.Application.UseCases
{
    public interface IUseCaseInput<out TUseCaseOutput> : IRequest<TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput
    {
    }
}

using demo_app.Application.Common.Interfaces;

namespace demo_app.Application.Calculator.Commands.Multiply;

public record MultiplyCommand : IRequest<decimal>
{
    public decimal Value1 { get; init; }
    public decimal Value2 { get; init; }
}

public class MultiplyCommandHandler(ICalculatorService calculatorService) : IRequestHandler<MultiplyCommand, decimal>
{
    public async Task<decimal> Handle(MultiplyCommand request, CancellationToken cancellationToken)
    {

        return await Task.Run(() => calculatorService.Multiply(request.Value1, request.Value2), cancellationToken);
    }
}

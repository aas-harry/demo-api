using demo_app.Application.Common.Interfaces;

namespace demo_app.Application.Calculator.Commands.Divide;

public record DivideCommand : IRequest<decimal>
{
    public decimal Dividend { get; init; }
    public decimal Divisor { get; init; }
}

public class DivideCommandHandler(ICalculatorService calculatorService) : IRequestHandler<DivideCommand, decimal>
{
    public async Task<decimal> Handle(DivideCommand request, CancellationToken cancellationToken)
    {

        return await Task.Run(() => calculatorService.Divide(request.Dividend, request.Divisor), cancellationToken);
    }
}

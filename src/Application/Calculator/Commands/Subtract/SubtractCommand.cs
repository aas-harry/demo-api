using demo_app.Application.Common.Interfaces;

namespace demo_app.Application.Calculator.Commands.Subtract;

public record SubtractCommand : IRequest<decimal>
{
    public decimal Minuend { get; init; }
    public decimal Subtrahend { get; init; }
}

public class SubtractCommandCommandHandler(ICalculatorService calculatorService) : IRequestHandler<SubtractCommand, decimal>
{
    public async Task<decimal> Handle(SubtractCommand request, CancellationToken cancellationToken)
    {

        return await Task.Run(() => calculatorService.Subtract(request.Minuend, request.Subtrahend), cancellationToken);
    }
}

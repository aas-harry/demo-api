using demo_app.Application.Common.Interfaces;

namespace demo_app.Application.Calculator.Commands.Add;

public record AddCommand : IRequest<decimal>
{
    public decimal Value1 { get; init; }
    public decimal Value2 { get; init; }
}

public class AddCommandHandler(ICalculatorService calculatorService) : IRequestHandler<AddCommand, decimal>
{
    public async Task<decimal> Handle(AddCommand request, CancellationToken cancellationToken)
    {

        return await Task.Run(() => calculatorService.Add(request.Value1, request.Value2), cancellationToken);
    }
}

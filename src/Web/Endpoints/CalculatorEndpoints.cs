using demo_app.Application.Calculator.Commands.Add;
using demo_app.Application.Calculator.Commands.Divide;
using demo_app.Application.Calculator.Commands.Multiply;
using demo_app.Application.Calculator.Commands.Subtract;
using Microsoft.AspNetCore.Http.HttpResults;

namespace demo_app.Web.Endpoints;

public class CalculatorEndpoints: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(Multiply, "multiply")
            .MapPost(Divide, "divide")
            .MapPost(Add, "add")
            .MapPost(Subtract, "subtract");
    }

    /// <summary>
    /// Multiply operation
    /// </summary>
    /// <returns></returns>
    public async Task<Ok<decimal>> Multiply(ISender sender, [AsParameters] MultiplyCommand command)
    {
        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }

    /// <summary>
    /// Division operation
    /// </summary>
    /// <returns></returns>
    public async Task<Ok<decimal>> Divide(ISender sender, [AsParameters] DivideCommand command)
    {
        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }

  
    public async Task<Ok<decimal>> Add(ISender sender, [AsParameters] AddCommand command)
    {

        var  result = await sender.Send(command);

        return TypedResults.Ok(result);
    }


    /// <summary>
    /// Subtraction operation
    /// </summary>
    /// <returns></returns>
    public async Task<Ok<decimal>> Subtract(ISender sender, [AsParameters] SubtractCommand command)
    {
        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }
}

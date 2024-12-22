using demo_app.Application.Common.Interfaces;

namespace demo_app.Application.Calculator;

/// <summary>
/// Calculator service
/// I created this service in the Application project.
/// NOTES: For large service we need to create it in its own projects.
/// </summary>
public class CalculatorService : ICalculatorService
{

    /// <summary>
    /// Multiply two numbers
    /// </summary>
    /// <param name="val1">First number</param>
    /// <param name="val2">Second number</param>
    /// <returns></returns>
    public decimal Multiply(decimal val1, decimal val2)
    {
        return val1 * val2;
    }

    /// <summary>
    /// Divide a number with another number
    /// </summary>
    /// <param name="dividend"></param>
    /// <param name="divisor"></param>
    /// <returns></returns>
    /// <exception cref="DivideByZeroException"></exception>
    public decimal Divide(decimal dividend, decimal divisor)
    {
        if (divisor == 0)
        {
            throw new DivideByZeroException();
        }
        return dividend / divisor;
    }

    /// <summary>
    /// Add 2 numbers
    /// </summary>
    /// <param name="val1"></param>
    /// <param name="val2"></param>
    /// <returns></returns>
    public decimal Add(decimal val1, decimal val2)
    {
        return val1 + val2;
    }

    /// <summary>
    /// Subtract a number
    /// </summary>
    /// <param name="minuend"></param>
    /// <param name="subtrahend"></param>
    /// <returns></returns>
    public decimal Subtract(decimal minuend, decimal subtrahend)
    {
        return minuend - subtrahend;
    }

}

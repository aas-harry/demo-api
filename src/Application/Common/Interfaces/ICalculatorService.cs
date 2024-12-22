namespace demo_app.Application.Common.Interfaces;
public interface ICalculatorService
{
    /// <summary>
    /// Multiply two numbers
    /// </summary>
    /// <param name="val1">First number</param>
    /// <param name="val2">Second number</param>
    /// <returns></returns>
    decimal Multiply(decimal val1, decimal val2);

    /// <summary>
    /// Divide a number with another number
    /// </summary>
    /// <param name="dividend"></param>
    /// <param name="divisor"></param>
    /// <returns></returns>
    /// <exception cref="DivideByZeroException"></exception>
    decimal Divide(decimal dividend, decimal divisor);

    /// <summary>
    /// Add 2 numbers
    /// </summary>
    /// <param name="val1"></param>
    /// <param name="val2"></param>
    /// <returns></returns>
    decimal Add(decimal val1, decimal val2);

    /// <summary>
    /// Subtract a number
    /// </summary>
    /// <param name="minuend"></param>
    /// <param name="subtrahend"></param>
    /// <returns></returns>
    decimal Subtract(decimal minuend, decimal subtrahend);

}

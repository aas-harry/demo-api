using demo_app.Application.Calculator;
using NUnit.Framework;

namespace demo_app.Application.UnitTests.Services;
public class CalculatorServiceTests
{
    private CalculatorService _calculatorService;

    [SetUp]
    public void Setup()
    {
        _calculatorService = new CalculatorService();
    }

    [Test]
    [TestCase(2.5, 4.0, 10.0)]
    [TestCase(0.0, 5.0, 0.0)]
    [TestCase(2.5, -4, -10)]
    // TestCase cannot accept decimal values such as 1.12m; therefore, we need to pass double values instead.
    public void Multiply_ReturnsCorrectResult(double val1, double val2, double expected)
    {
        // Arrange 
        var dec1 = (decimal)val1;
        var dec2 = (decimal)val2;

        // Act
        var actual = _calculatorService.Multiply(dec1, dec2);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(2.5, 4.0, 0.625)]
    [TestCase(0.0, 5.0, 0.0)]
    [TestCase(2.5, -4, -0.625)]
    public void Divide_ReturnsCorrectResult(double val1, double val2, double expected)
    {
        // Arrange
        var dec1 = (decimal)val1;
        var dec2 = (decimal)val2;

        // Act
        var actual = _calculatorService.Divide(dec1, dec2);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));

    }

    [Test]
    public void Divide_NegativeValue_ThrowsDivideByZeroException()
    {
        // Act
        Assert.That(() => _calculatorService.Divide(10, 0), Throws.TypeOf<DivideByZeroException>());
        
    }

    [Test]
    [TestCase(1, 1, 2)]
    [TestCase(-1, -1, -2)]
    [TestCase(10, -1, 9)]
    [TestCase(-11, 2, -9)]
    [TestCase(-123.4, 2.2, -121.2)]
    public void Add_ReturnsCorrectResult(double val1, double val2, double expected)
    {
        // Arrange
        // Arrange 
        var dec1 = (decimal)val1;
        var dec2 = (decimal)val2;

        // Act
        var actual = _calculatorService.Add(dec1, dec2);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(1, 1, 0)]
    [TestCase(-1, -1, 0)]
    [TestCase(10, -1, 11)]
    [TestCase(-11, 2, -13)]
    [TestCase(-123.4, 2.2, -125.6)]
    public void Subtract_ReturnsCorrectResult(double val1, double val2, double expected)
    {
        // Arrange
        // Arrange 
        var dec1 = (decimal)val1;
        var dec2 = (decimal)val2;

        // Act
        var actual = _calculatorService.Subtract(dec1, dec2);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}

using demo_app.Application.Calculator.Commands.Divide;
using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;
using static Testing;
public class DivideTests : BaseTestFixture
{
    [Test]
    public async Task ShouldDivideTwoNumber()
    {
        // Arrange
        const decimal expectedValue = 0.5M;
        var userId = Guid.NewGuid();
        var command = new DivideCommand()
        {
            Dividend = 1,
            Divisor = 2
        };
        ((IUserId)command).SetUserId(userId);

        // Acts
        var actual = await SendAsync(command);

        // Assert
        Assert.That(await CountAsync<CalculationItem>(e => e.UserId == userId && e.Operation == CalculationOperation.Divide)
            , Is.EqualTo(1));
        actual.Should().Be(expectedValue);
    }
}

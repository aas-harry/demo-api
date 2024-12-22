using demo_app.Application.Calculator.Commands.Multiply;
using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;

using static Testing;
public class MultiplyTests : BaseTestFixture
{
    [Test]
    public async Task ShouldMultiplyTwoNumber()
    {
        // Arrange
        const int expectedValue = 2;
        var userId = Guid.NewGuid();
        var command = new MultiplyCommand()
        {
            Value1 = 1,
            Value2 = 2
        };
        ((IUserId)command).SetUserId(userId);

        // Act
        var actual = await SendAsync(command);

        // Assert
        Assert.That(await CountAsync<CalculationItem>(e => e.UserId == userId && e.Operation == CalculationOperation.Multiply)
            , Is.EqualTo(1)); actual.Should().Be(expectedValue);
        actual.Should().Be(expectedValue);
    }
}


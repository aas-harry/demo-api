using demo_app.Application.Calculator.Commands.Add;
using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;

using static Testing;
public class AddTests: BaseTestFixture
{
    [Test]
    public async Task ShouldAddTwoNumber()
    {
        // Arrange
        const int expectedValue = 3;
        var userId = Guid.NewGuid();
        var command = new AddCommand
        {
            Value1 = 1,
            Value2 = 2
        };
        ((IUserId)command).SetUserId(userId);

        // Act
        var actual = await SendAsync(command);

        // Assert
        Assert.That(await CountAsync<CalculationItem>(e => e.UserId == userId && e.Operation == CalculationOperation.Add)
            , Is.EqualTo(1));
        actual.Should().Be(expectedValue);
    }
}

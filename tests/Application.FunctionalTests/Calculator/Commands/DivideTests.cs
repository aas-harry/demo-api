using demo_app.Application.Calculator.Commands.Divide;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;
using static Testing;
public class DivideTests : BaseTestFixture
{
    [Test]
    public async Task ShouldDivideTwoNumber()
    {
        const decimal expectedValue = 0.5M;
        var command = new DivideCommand()
        {
            Dividend = 1,
            Divisor = 2
        };

        var actual = await SendAsync(command);

        actual.Should().Be(expectedValue);
    }
}

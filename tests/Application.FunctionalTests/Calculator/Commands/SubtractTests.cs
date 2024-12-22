using demo_app.Application.Calculator.Commands.Subtract;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;

using static Testing;
public class SubtractTests : BaseTestFixture
{
    [Test]
    public async Task ShouldSubtractNumber()
    {
        const decimal expectedValue = -1M;
        var command = new SubtractCommand
        {
            Minuend = 1,
            Subtrahend = 2
        };

        var actual = await SendAsync(command);

        actual.Should().Be(expectedValue);
    }
}

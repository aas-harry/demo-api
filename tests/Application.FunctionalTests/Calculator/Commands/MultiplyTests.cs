using demo_app.Application.Calculator.Commands.Multiply;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;

using static Testing;
public class MultiplyTests : BaseTestFixture
{
    [Test]
    public async Task ShouldMultiplyTwoNumber()
    {
        const int expectedValue = 2;
        var command = new MultiplyCommand()
        {
            Value1 = 1,
            Value2 = 2
        };

        var actual = await SendAsync(command);

        actual.Should().Be(expectedValue);
    }
}


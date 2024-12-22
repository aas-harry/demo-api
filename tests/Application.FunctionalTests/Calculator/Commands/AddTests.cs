using demo_app.Application.Calculator.Commands.Add;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;

using static Testing;
public class AddTests: BaseTestFixture
{
    [Test]
    public async Task ShouldAddTwoNumber()
    {
        const int expectedValue = 3;
        var command = new AddCommand
        {
            Value1 = 1,
            Value2 = 2
        };

        var actual = await SendAsync(command);

        actual.Should().Be(expectedValue);
    }
}

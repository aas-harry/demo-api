﻿using demo_app.Application.Calculator.Commands.Subtract;
using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.FunctionalTests.Calculator.Commands;

using static Testing;
public class SubtractTests : BaseTestFixture
{
    [Test]
    public async Task ShouldSubtractNumber()
    {
        // Arrange
        const decimal expectedValue = -1M;
        var userId = Guid.NewGuid();
        var command = new SubtractCommand
        {
            Minuend = 1,
            Subtrahend = 2
        };
        ((IUserId)command).SetUserId(userId);

        // Act
        var actual = await SendAsync(command);

        // Assert
        Assert.That(await CountAsync<CalculationItem>(e => e.UserId == userId && e.Operation == CalculationOperation.Subtract)
            , Is.EqualTo(1));
        actual.Should().Be(expectedValue);
    }
}

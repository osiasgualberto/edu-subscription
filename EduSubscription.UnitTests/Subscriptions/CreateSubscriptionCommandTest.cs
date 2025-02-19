﻿using EduSubscription.Application.Subscriptions.Commands.CreateSubscription;
using EduSubscription.Core.Plans.Errors;
using EduSubscription.Core.Subscriptions.Errors;
using EduSubscription.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace EduSubscription.UnitTests.Subscriptions;

public class CreateSubscriptionCommandTest
{
    public CreateSubscriptionCommandTest()
    {
        var subscriptionRepository = Substitute.For<ISubscriptionRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _unitOfWorkMock.SubscriptionRepository = subscriptionRepository;
    }

    private readonly IUnitOfWork _unitOfWorkMock;
    
    [Fact]
    public async Task HandlerShouldReturnErrorIfPlanNotExists()
    {
        // Arrange
        _unitOfWorkMock
            .SubscriptionRepository
            .ReadById(Arg.Any<Guid>())
            .ReturnsNull();
        var command = new CreateSubscriptionCommand(Arg.Any<Guid>(), Arg.Any<Guid>());
        var handler = new CreateSubscriptionCommandHandler(_unitOfWorkMock);
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        Assert.Equal(result.Error, PlanErrors.Plan.PlanNotFound);
    }
}
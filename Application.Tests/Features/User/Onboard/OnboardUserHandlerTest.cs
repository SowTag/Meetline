using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.User.OnboardUser;
using Application.Repositories;
using Moq;
using Xunit;

namespace Application.Tests.Features.User.Onboard;

public class OnboardUserHandlerTest
{
    private readonly OnboardUserHandler _handler;
    private readonly Mock<IUserRepository> _repositoryMock;

    public OnboardUserHandlerTest()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _handler = new OnboardUserHandler(_repositoryMock.Object);
    }

    [Fact(DisplayName = "Should return OK when the user is not onboarded")]
    public async Task Handle_UserIsNotOnboarded_ShouldReturnOk()
    {
        var command = new OnboardUserCommand("idp|123456", "user", "user@test.com", "First", "Last");

        _repositoryMock
            .Setup(repo => repo.GetUserIdFromExternalId(command.ExternalId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Guid?)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsSuccess);
        _repositoryMock.Verify(
            repo => repo.CreateAsync(It.IsAny<Domain.Entities.User>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "Should return Conflict when the user is already onboarded")]
    public async Task Handle_UserIsAlreadyOnboarded_ShouldReturnConflict()
    {
        var command = new OnboardUserCommand("idp|123456", "user", "user@test.com", "First", "Last");

        _repositoryMock
            .Setup(repo => repo.GetUserIdFromExternalId(command.ExternalId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(Guid.NewGuid());

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.True(result.IsFailed);
        var err = Assert.Single(result.Errors);
        Assert.IsType<ApplicationError>(err);
        Assert.Equal(ErrorType.Conflict, ((ApplicationError)err).Type);
    }
}
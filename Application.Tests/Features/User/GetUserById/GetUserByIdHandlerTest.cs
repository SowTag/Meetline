using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.User.GetUserById;
using Application.Repositories;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace Application.Tests.Features.User.GetUserById;

[TestSubject(typeof(GetUserByIdHandler))]
public class GetUserByIdHandlerTest
{
    private readonly GetUserByIdHandler _handler;
    private readonly Mock<IUserRepository> _repositoryMock;

    public GetUserByIdHandlerTest()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _handler = new GetUserByIdHandler(_repositoryMock.Object);
    }

    [Fact(DisplayName = "Base case; should return the user properly")]
    public async Task Handle_WhenUserExists_ShouldReturnUserResponse()
    {
        var userId = Guid.NewGuid();
        var query = new GetUserByIdQuery(userId);

        var expectedUser = new Domain.Entities.User { Id = userId };

        _repositoryMock
            .Setup(repo => repo.GetUserById(query.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedUser);

        var result = await _handler.Handle(query, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.IsType<GetUserByIdResponse>(result.Value);
        Assert.Equal(userId, result.Value.Id);
    }

    [Fact(DisplayName =
        "Should return a result of the NotFound variant when the user doesn't exist")]
    public async Task Handle_WhenUserDoesNotExist_ShouldReturnNotFoundError()
    {
        var userId = Guid.NewGuid();
        var query = new GetUserByIdQuery(userId);

        _repositoryMock
            .Setup(repo => repo.GetUserById(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Domain.Entities.User)null);

        var result = await _handler.Handle(query, CancellationToken.None);

        Assert.True(result.IsFailed);
        var err = Assert.Single(result.Errors);
        Assert.IsType<ApplicationError>(err);
        Assert.Equal(ErrorType.NotFound, ((ApplicationError)err).Type);
    }
}
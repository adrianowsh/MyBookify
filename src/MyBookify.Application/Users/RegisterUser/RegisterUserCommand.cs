using MyBookify.Application.Abstractions.Messaging;

namespace MyBookify.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<Guid>;



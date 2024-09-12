using MyBookify.Application.Abstractions.Messaging;

namespace MyBookify.Application.Users.LoginUser;
public sealed record LogInUserCommand(string Email, string Password)
    : ICommand<AccessTokenResponse>;

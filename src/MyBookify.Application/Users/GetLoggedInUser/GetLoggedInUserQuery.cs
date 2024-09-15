using MyBookify.Application.Abstractions.Messaging;

namespace MyBookify.Application.Users.GetLoggedInUser;
public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;

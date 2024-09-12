﻿using MyBookify.Domain.Users;

namespace MyBookify.Application.Abstractions.Authentication;
public interface IAuthenticationService
{
    Task<string> RegisterAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default);
}

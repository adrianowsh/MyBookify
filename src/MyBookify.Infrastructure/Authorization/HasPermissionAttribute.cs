using Microsoft.AspNetCore.Authorization;

namespace MyBookify.Infrastructure.Authorization;

[AttributeUsage(AttributeTargets.Method, Inherited = true)]
public sealed class HasPermissionAttribute : AuthorizeAttribute
{

    public HasPermissionAttribute(string permission)
        : base(permission)
    {
    }
}


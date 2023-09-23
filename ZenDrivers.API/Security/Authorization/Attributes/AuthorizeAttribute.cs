using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ZenDrivers.API.Security.Domain.Models;
using ZenDrivers.API.Shared.Domain.Enums;

namespace ZenDrivers.API.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly UserType[] _allowUserTypes;

    public AuthorizeAttribute() => _allowUserTypes = new []{ UserType.Driver, UserType.Recruiter };
    public AuthorizeAttribute(params UserType[] allowUserTypes) => _allowUserTypes = allowUserTypes;
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //If action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        //Then skip authorization process
        if (allowAnonymous)
            return;

        // Authorization process
        if (context.HttpContext.Items["User"] is not Account user || !_allowUserTypes.Contains(user.Role))
            context.Result = new JsonResult(new { message = "Unathorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
}

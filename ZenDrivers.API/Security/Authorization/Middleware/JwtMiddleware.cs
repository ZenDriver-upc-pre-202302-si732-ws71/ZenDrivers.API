﻿using Microsoft.Extensions.Options;
using ZenDrivers.API.Security.Authorization.Handlers.Interfaces;
using ZenDrivers.API.Security.Authorization.Settings;
using ZenDrivers.API.Security.Domain.Services;

namespace ZenDrivers.API.Security.Authorization.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IAccountService accountService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = handler.ValidateToken(token);
        if(userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = await accountService.GetByIdAsync(userId.Value);
        }
        await _next(context);
    }
}

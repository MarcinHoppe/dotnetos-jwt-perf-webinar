using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Dotnetos.Authentication
{
    public static class CachingJwtBearerExtensions
    {
        public static AuthenticationBuilder AddCachingJwtBearer(
            this AuthenticationBuilder builder,
            Action<JwtBearerOptions> configureOptions)
        {
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<IPostConfigureOptions<JwtBearerOptions>, JwtBearerPostConfigureOptions>());
            
            return builder.AddScheme<JwtBearerOptions, CachingJwtBearerHandler>(
                    JwtBearerDefaults.AuthenticationScheme,
                    displayName: null,
                    configureOptions: configureOptions
            );
        }
    }
}
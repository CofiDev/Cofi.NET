using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Cofi.Authentication.Tokens
{
    public static class AuthenticationTokensDependencyBuilderExtensions
    {
        public static AuthenticationTokensDependencyBuilder AddJwtBearer(this AuthenticationTokensDependencyBuilder builder, AccessTokenOptions options)
        {
            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(_ =>
                {
                    _.RequireHttpsMetadata = false;
                    _.SaveToken = true;
                    _.TokenValidationParameters = new()
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = options.Issuer,
                        ValidAudience = options.Audience,
                        IssuerSigningKey = options.GetSymmetricSecurityKey()
                    };

                    _.Events = new()
                    {
                        OnAuthenticationFailed = context => 
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                context.Response.Headers.Add(options.ExpiredHeaderName,"EXPIRED");

                            return Task.CompletedTask;
                        }
                    };
                });
            return builder;
        }
    }
}
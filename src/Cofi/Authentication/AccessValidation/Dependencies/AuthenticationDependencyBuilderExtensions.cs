using Microsoft.Extensions.DependencyInjection;

namespace Cofi.Authentication.AccessValidation
{
    internal static class AuthenticationDependencyBuilderExtensions
    {
        public static AuthenticationDependencyBuilder AddAccessValidation(this AuthenticationDependencyBuilder builder)
        {
            builder.Services
                .AddSingleton<IAccessValidator, AccessValidator>();
                
            return builder;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace Cofi.Authentication.AccessValidation
{
    public static class AuthenticationDependencyBuilderExtensions
    {
        public static AuthenticationDependencyBuilder AddAccessValidation(this AuthenticationDependencyBuilder builder)
        {
            builder.Services
                .AddSingleton<IAccessValidator, AccessValidator>()
                .AddValidateAccessImplsFromAssemblyOf<AuthenticationDependencyBuilder>();
                
            return builder;
        }
    }
}
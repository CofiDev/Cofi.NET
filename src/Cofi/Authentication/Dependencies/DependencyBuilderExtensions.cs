using Cofi.Authentication.AccessValidation;

namespace Cofi.Authentication
{
    public static class DependencyBuilderExtensions
    {
        public static AuthenticationDependencyBuilder AddAuthenticationCore(this DependencyBuilder builder) => new(builder.Services);

        public static AuthenticationDependencyBuilder AddAuthentication(this DependencyBuilder builder) => builder.AddAuthenticationCore()
            .AddAccessValidation();
    }
}
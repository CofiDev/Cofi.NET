namespace Cofi.Authentication
{
    public static class DependencyBuilderExtensions
    {
        public static AuthenticationDependencyBuilder AddAuthenticationBase(this DependencyBuilder builder) => new(builder.Services);

        public static AuthenticationDependencyBuilder AddAuthentication(this DependencyBuilder builder) => builder.AddAuthenticationBase();
    }
}
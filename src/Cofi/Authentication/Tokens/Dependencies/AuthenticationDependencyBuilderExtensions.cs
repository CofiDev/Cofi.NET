using Microsoft.Extensions.DependencyInjection;

namespace Cofi.Authentication.Tokens
{
    public static class AuthenticationDependencyBuilderExtensions
    {
        public static AuthenticationTokensDependencyBuilder AddTokensBase(this AuthenticationDependencyBuilder builder) => new(builder.Services);

        public static AuthenticationTokensDependencyBuilder AddTokens(this AuthenticationDependencyBuilder builder)
        {
            var localBuilder = builder.AddTokensBase();

            localBuilder.Services
                .AddSingleton<IAccessTokenGenerator, AccessTokenGenerator>();

            return localBuilder;
        }

    }
}
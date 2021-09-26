using Microsoft.Extensions.DependencyInjection;

namespace Cofi.Authentication.Tokens
{
    public class AuthenticationTokensDependencyBuilder : AuthenticationDependencyBuilder
    {
        public AuthenticationTokensDependencyBuilder(IServiceCollection services) : base(services)
        {
        }
    }
}
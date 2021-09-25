using Microsoft.Extensions.DependencyInjection;

namespace Cofi.Authentication
{
    public class AuthenticationDependencyBuilder : DependencyBuilder
    {
        public AuthenticationDependencyBuilder(IServiceCollection services) : base(services)
        {
        }
    }
}
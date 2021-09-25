using Cofi.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Cofi
{
    public static class IServiceCollectionExtensions
    {
        public static DependencyBuilder AddCofi(this IServiceCollection services)
        {
            var dependencyBuilder = new DependencyBuilder(services);

            return dependencyBuilder
                .AddServiceFactory()
                .AddAuthentication();
        }
    }
}
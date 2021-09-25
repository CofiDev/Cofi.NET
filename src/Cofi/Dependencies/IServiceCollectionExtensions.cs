using Cofi.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Cofi
{
    public static class IServiceCollectionExtensions
    {
        public static DependencyBuilder AddCofiCore(this IServiceCollection services) => new(services);

        public static DependencyBuilder AddCofi(this IServiceCollection services) => services.AddCofiCore()
            .AddServiceFactory()
            .AddAuthentication();
    }
}
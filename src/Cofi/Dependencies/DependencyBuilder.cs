using Microsoft.Extensions.DependencyInjection;

namespace Cofi
{
    public class DependencyBuilder
    {
        public IServiceCollection Services { get; }

        public DependencyBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
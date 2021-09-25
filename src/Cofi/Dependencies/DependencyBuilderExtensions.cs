using Microsoft.Extensions.DependencyInjection;

namespace Cofi
{
    internal static class DependencyBuilderExtensions
    {
        public static DependencyBuilder AddServiceFactory(this DependencyBuilder builder) 
        {
            builder.Services
                .AddSingleton<ServiceFactory>(provider => provider.GetService);
                
            return builder;
        }
    }
}
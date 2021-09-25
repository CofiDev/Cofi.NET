using Microsoft.Extensions.DependencyInjection;

namespace Cofi.Authentication
{
    internal static class DependencyBuilderExtensions
    {
        public static DependencyBuilder AddAuthentication(this DependencyBuilder builder)
        {
            builder.Services
                .AddSingleton<IAccessValidator, AccessValidator>();
                
            return builder;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace Cofi.Utilities
{
    public static class DependencyBuilderExtensions
    {
        public static DependencyBuilder AddUtilities(this DependencyBuilder builder)
        {
            builder.Services
                .AddSingleton<ClaimValuesParser>();

            return builder;
        }
    }
}
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cofi.Authentication.AccessValidation
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddValidateAccessImplsFromAssembly(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var impls = assembly.GetTypes().Where(type => type.IsConcreteImplOf(typeof(IValidateAccess<>)));

            if (impls.Any())
                foreach (var impl in impls)
                {
                    var contract = impl.GetInterfaces()
                        .Where(_ => _.IsGenericType && _.GetGenericTypeDefinition().Equals(typeof(IValidateAccess<>)))
                        .First();
                    
                    services.TryAdd(new ServiceDescriptor(impl, impl, lifetime));
                    services.TryAdd(new ServiceDescriptor(contract, impl, lifetime));
                }

            return services;
        }

        public static IServiceCollection AddValidateAccessImplsFromAssemblyOf<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped) => services.AddValidateAccessImplsFromAssembly(typeof(T).Assembly);
    }
}
using System;

namespace Cofi
{
    public delegate object? ServiceFactory(Type serviceType);

    public static class ServiceFactoryExtensions
    {
        public static T? GetInstance<T>(this ServiceFactory factory) => (T?)factory(typeof(T));
    }
}
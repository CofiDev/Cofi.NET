using System.Threading;
using System.Threading.Tasks;
using System;

namespace Cofi.Authentication.AccessValidation
{
    internal abstract class ValidateAccessWrapperBase
    {
        public abstract Task<bool> ValidateAsync(object rule, ServiceFactory factory, CancellationToken cancellationToken);

        protected static T GetImplementation<T>(ServiceFactory factory)
        {
            T? implementation;

            try
            {
                implementation = factory.GetInstance<T>();
            }
            catch (Exception)
            {
                throw;
            }

            return implementation ?? throw new InvalidOperationException($"{nameof(implementation)} is null");
        }
    }
}
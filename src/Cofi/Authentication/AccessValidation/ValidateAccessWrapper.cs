using System.Threading;
using System.Threading.Tasks;

namespace Cofi.Authentication.AccessValidation
{
    internal abstract class ValidateAccessWrapper<TAccessValidationRule> : ValidateAccessWrapperBase
        where TAccessValidationRule : IAccessValidationRule
    {
        public abstract Task<bool> ValidateAsync(TAccessValidationRule rule, ServiceFactory factory, CancellationToken cancellationToken);
    }
}
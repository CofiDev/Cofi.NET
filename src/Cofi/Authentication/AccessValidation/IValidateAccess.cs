using System.Threading;
using System.Threading.Tasks;

namespace Cofi.Authentication.AccessValidation
{
    public interface IValidateAccess<TRule> where TRule : IAccessValidationRule
    {
        public ValueTask<bool> ValidateAsync(TRule rule, CancellationToken cancellationToken = default);
    }
}
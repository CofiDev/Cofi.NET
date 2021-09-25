using System.Threading;
using System.Threading.Tasks;

namespace Cofi.Authentication
{
    public interface IAccessValidator
    {
        Task<bool> ValidateAsync(AccessValidationMode mode, IAccessValidationRuleEnumerable rules, CancellationToken cancellationToken = default);        
    }
}
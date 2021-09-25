using System.Threading;
using System.Threading.Tasks;

namespace Cofi.Authentication.Tokens
{
    public interface IRefreshTokenValidator
    {
        bool Validate(RefreshTokenValidatorInput input);
        Task<bool> ValidateAsync(RefreshTokenValidatorInput input, CancellationToken cancellationToken = default);
    }
}
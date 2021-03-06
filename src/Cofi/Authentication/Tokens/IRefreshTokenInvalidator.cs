using System.Threading;
using System.Threading.Tasks;

namespace Cofi.Authentication.Tokens
{
    public interface IRefreshTokenInvalidator
    {
        bool Invalidate(RefreshTokenInvalidatorInput input);
        Task<bool> InvalidateAsync(RefreshTokenInvalidatorInput input, CancellationToken cancellationToken = default);
    }
}
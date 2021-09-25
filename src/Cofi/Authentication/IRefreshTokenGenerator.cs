using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Cofi.Authentication
{
    public interface IRefreshTokenGenerator
    {
        string Generate(AccessToken accessToken);
        Task<string> GenerateAsync(AccessToken accessToken, CancellationToken cancellationToken = default);
    }
}
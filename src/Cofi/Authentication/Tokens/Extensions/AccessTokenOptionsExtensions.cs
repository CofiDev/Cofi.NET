using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Cofi.Authentication.Tokens
{
    public static class AccessTokenOptionsExtensions
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey(this AccessTokenOptions options) => new(Encoding.UTF8.GetBytes(options.Key));

        public static SigningCredentials GetSigningCredentials(this AccessTokenOptions options, string algorithm = SecurityAlgorithms.HmacSha256) => new(options.GetSymmetricSecurityKey(), algorithm);
    }
}
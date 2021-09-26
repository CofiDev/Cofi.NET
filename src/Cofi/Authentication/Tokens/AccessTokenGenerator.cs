using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

namespace Cofi.Authentication.Tokens
{
    internal sealed class AccessTokenGenerator : IAccessTokenGenerator
    {
        private static readonly JwtSecurityTokenHandler _tokenHandler = new();

        private readonly IOptions<AccessTokenOptions> _options;

        public AccessTokenGenerator(IOptions<AccessTokenOptions> options)
        {
            _options = options;
        }

        public AccessToken Generate(TokenInput input)
        {
            var options = _options.Value;
            var token = new JwtSecurityToken
            (
                issuer: options.Issuer,
                audience: options.Audience,
                signingCredentials: options.GetSigningCredentials(),
                expires: DateTime.UtcNow + options.Expiration,
                claims: input.ToClaims(options.Claims)
            );
            
            return new()
            {
                TokenId = Guid.NewGuid().ToString(),
                TokenString = _tokenHandler.WriteToken(token)
            };
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Cofi.Authentication.Tokens
{
    public static class TokenInputExtensions
    {
        public static IEnumerable<Claim> ToClaims(this TokenInput input, AccessTokenOptions.ClaimsObj options)
    {
        var claims = new List<Claim>
        {
            new Claim(options.Lookup.ClientDeviceId, input.ClientDeviceId),
            new Claim(options.Lookup.UserId, input.UserId)
        };

        if (input.Username is not null)
            claims.Add(new Claim(options.Lookup.Username, input.Username));

        if (input.Roles.Any())
            claims.Add(new Claim(options.Lookup.Roles, input.Roles.Aggregate((set, item) => $"{set}{options.ValuesSeparator}{item}")));

        if (input.Permissions.Any())
            claims.Add(new Claim(options.Lookup.Permissions, input.Permissions.Aggregate((set, item) => $"{set}{options.ValuesSeparator}{item}")));

        return claims;
    }
    }
}
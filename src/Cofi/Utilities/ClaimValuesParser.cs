using System.Runtime.CompilerServices;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;

namespace Cofi.Utilities
{
    public sealed class ClaimValuesParser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ClaimValuesParser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private string[] SplitClaimValue(string value, char[] separators) => value.Split(separators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        public IEnumerable<string> Parse(string claimType, params char[] separators)
        {
            var context = _contextAccessor.HttpContext;
            var claim = _contextAccessor?.HttpContext?.User.FindFirst(claimType);
            
            if (claim is not null && !string.IsNullOrWhiteSpace(claim.Value))
                return SplitClaimValue(claim.Value, separators);

            return Enumerable.Empty<string>();
        }
    }
}
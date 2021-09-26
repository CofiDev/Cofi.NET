using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cofi.Authentication.Tokens;
using Cofi.Utilities;
using Microsoft.Extensions.Options;

namespace Cofi.Authentication.AccessValidation
{
    internal sealed class VAByRole : IValidateAccess<AVRPermission>
    {
        private readonly object _lockObj = new();
        private readonly string _claimType;
        private readonly char _separator;
        private readonly ClaimValuesParser _claimValuesParser;

        private HashSet<string> roles = default!;
        private bool isLoaded = false;

        public VAByRole(IOptions<AccessTokenOptions> options, ClaimValuesParser claimValuesParser)
        {
            _claimType = options.Value.Claims.Lookup.Roles;
            _separator = options.Value.Claims.ValuesSeparator;
            _claimValuesParser = claimValuesParser;
        }

        public ValueTask<bool> ValidateAsync(AVRPermission rule, CancellationToken cancellationToken = default)
        {
            TryLoad();
            return ValueTask.FromResult(roles.Contains(rule.Permission));
        }

        private void TryLoad()
        {
            if (!isLoaded)
            {
                lock (_lockObj)
                {
                    roles = new(_claimValuesParser.Parse(_claimType, _separator));
                    isLoaded = true;
                }
            }
        }
    }
}
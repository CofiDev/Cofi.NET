using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cofi.Authentication.Tokens;
using Cofi.Utilities;
using Microsoft.Extensions.Options;

namespace Cofi.Authentication.AccessValidation
{
    internal sealed class VAByPermission : IValidateAccess<AVRPermission>
    {
        private readonly object _lockObj = new();
        private readonly string _claimType;
        private readonly char _separator;
        private readonly ClaimValuesParser _claimValuesParser;

        private HashSet<string> permissions = default!;
        private bool isLoaded = false;

        public VAByPermission(IOptions<AccessTokenOptions> options, ClaimValuesParser claimValuesParser)
        {
            _claimType = options.Value.Claims.Lookup.Permissions;
            _separator = options.Value.Claims.ValuesSeparator;
            _claimValuesParser = claimValuesParser;
        }

        public ValueTask<bool> ValidateAsync(AVRPermission rule, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        private void TryLoad() 
        {
            if (!isLoaded)
            {
                lock (_lockObj)
                {
                     permissions = new(_claimValuesParser.Parse(_claimType, _separator));
                     isLoaded = true;
                }
            }
        }
    }
}
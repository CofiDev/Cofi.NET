using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Cofi.Authentication.Tokens
{
    public record TokenInput
    {
        public string ClientDeviceId { get; init; } = default!;
        public string UserId { get; init; } = default!;
        public string? Username { get; init; }
        public IEnumerable<string> Roles { get; init; } = Enumerable.Empty<string>();
        public IEnumerable<string> Permissions { get; init; } = Enumerable.Empty<string>();
    }
}
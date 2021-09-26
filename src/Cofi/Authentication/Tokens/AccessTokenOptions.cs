using System;

namespace Cofi.Authentication.Tokens
{
    public sealed class AccessTokenOptions
    {
        public string Key { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public TimeSpan Expiration { get; set; }
        public string HeaderName { get; set; } = default!;
        public string ExpiredHeaderName { get; set; } = default!;
        public ClaimsObj Claims { get; set; } = new();

        public sealed class ClaimsObj
        {
            public char ValuesSeparator { get; set; }
            public LookupObj Lookup { get; set; } = new();

            public sealed class LookupObj
            {
                public string ClientDeviceId { get; set; } = default!;
                public string UserId { get; set; } = default!;
                public string Username { get; set; } = default!;
                public string Roles { get; set; } = default!;
                public string Permissions { get; set; } = default!;
            }
        }
    }
}
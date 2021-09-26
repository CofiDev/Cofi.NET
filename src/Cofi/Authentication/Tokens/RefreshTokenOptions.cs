using System;

namespace Cofi.Authentication.Tokens
{
    public sealed class RefreshTokenOptions
    {
        public TimeSpan Expiration { get; set; }
        public string CookieName { get; set; } = default!;
    }
}
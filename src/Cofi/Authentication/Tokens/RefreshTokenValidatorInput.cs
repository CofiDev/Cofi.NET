namespace Cofi.Authentication.Tokens
{
    public record RefreshTokenValidatorInput
    {
        public string ClientDeviceId { get; init; } = default!;
        public string UserId { get; init; } = default!;
        public string RefreshToken { get; init; } = default!;
    }
}
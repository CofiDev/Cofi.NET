namespace Cofi.Authentication.Tokens
{
    public record RefreshTokenInvalidatorInput
    {
        public string ClientDeviceId { get; init; } = default!;
        public string UserId { get; init; } = default!;
    }
}
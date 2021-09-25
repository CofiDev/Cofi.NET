namespace Cofi.Authentication
{
    public record RefreshTokenInvalidatorInput
    {
        public string ClientDeviceId { get; init; } = default!;
        public string UserId { get; init; } = default!;
    }
}
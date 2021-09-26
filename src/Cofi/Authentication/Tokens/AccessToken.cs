namespace Cofi.Authentication.Tokens
{
    public record AccessToken
    {
        public string TokenId { get; init; } = default!;
        public string TokenString { get; init; } = default!;
    }
}
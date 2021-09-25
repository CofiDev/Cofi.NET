namespace Cofi.Authentication.Tokens
{
    public interface IAccessTokenGenerator
    {
        AccessToken Generate(TokenInput input);
    }
}
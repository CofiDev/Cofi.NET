namespace Cofi.Authentication
{
    public interface IAccessTokenGenerator
    {
        AccessToken Generate(TokenInput input);
    }
}
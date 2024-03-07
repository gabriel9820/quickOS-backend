namespace quickOS.Application.DTOs.OutputModels;

public class TokensOutputModel
{
    public string AccessToken { get; private set; }
    public Guid RefreshToken { get; private set; }

    public TokensOutputModel(string accessToken, Guid refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}

public class LoginOutputModel : TokensOutputModel
{
    public UserOutputModel User { get; private set; }

    public LoginOutputModel(string accessToken, Guid refreshToken, UserOutputModel user) : base(accessToken, refreshToken)
    {
        User = user;
    }
}

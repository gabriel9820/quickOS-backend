namespace quickOS.Application.DTOs.OutputModels;

public class LoginOutputModel
{
    public string AccessToken { get; private set; }
    public UserOutputModel User { get; private set; }

    public LoginOutputModel(string accessToken, UserOutputModel user)
    {
        AccessToken = accessToken;
        User = user;
    }
}

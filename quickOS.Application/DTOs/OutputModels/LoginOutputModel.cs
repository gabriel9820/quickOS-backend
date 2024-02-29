namespace quickOS.Application.DTOs.OutputModels;

public class LoginOutputModel
{
    public string AccessToken { get; private set; }
    public AuthenticatedUserOutputModel User { get; private set; }

    public LoginOutputModel(string accessToken, AuthenticatedUserOutputModel user)
    {
        AccessToken = accessToken;
        User = user;
    }
}

public class AuthenticatedUserOutputModel
{
    public string FullName { get; private set; }
    public string Email { get; private set; }

    public AuthenticatedUserOutputModel(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }
}

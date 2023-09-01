namespace MSQL.Models;

using MSQL.Data;

public class AuthenticateResponse
{

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        FirstName = user.FistName;
        LastName = user.LastName;
        Email = user.Email;
        Token = token;
    }
}
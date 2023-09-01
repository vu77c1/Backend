using MSQL.Data;

namespace MSQL.Models;
public class UserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }


    public UserResponse(User user)
    {
        Id = user.Id;
        FirstName = user.FistName;
        LastName = user.LastName;
        Email = user.Email;
    }

}

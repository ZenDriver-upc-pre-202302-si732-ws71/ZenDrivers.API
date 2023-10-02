namespace ZenDrivers.API.Security.Domain.Services.Communication;
public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
    
    public string Role { get; set; }

}

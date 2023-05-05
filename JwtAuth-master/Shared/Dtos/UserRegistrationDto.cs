namespace Shared.Dtos;

public class UserRegistrationDto
{
    public int UserId { get; set; }
    public string Username { get; }
    public string Password { get; }
    public string Email { get; set; }
    public string Domain { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }

    public UserRegistrationDto(string userName, string password, string email, string domain, string name, string role)
    {
        Username = userName;
        Password = password;
        Email = email;
        Domain = domain;
        Name = name;
        Role = role;
    }
}
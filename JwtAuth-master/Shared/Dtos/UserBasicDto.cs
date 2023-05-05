namespace Shared.Dtos;

public class UserBasicDto
{
    public int Id { get; }
    public string Username { get; }
    public string Password { get; }
    public string Email { get; }
    public string Domain { get; }
    public string Name { get; }
    public string Role { get; }
    public int Age { get; }
    public int SecurityLevel { get; }

    public UserBasicDto(int id, string username, string password, string email, string domain, string name, string role,
        int age, int securityLevel)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        Domain = domain;
        Name = name;
        Role = role;
        Age = age;
        SecurityLevel = securityLevel;
    }
}
using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{

    private readonly IUserDao userDao;
    
    public AuthService(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    private readonly IList<User> users = new List<User>
    {
    };

    /*public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }*/
    public Task<User> ValidateUser(string username, string password)
    {
        return userDao.Validation(username, password);
    }

    /*public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }*/
    public Task RegisterUser(UserRegistrationDto dto)
    {

        if (string.IsNullOrEmpty(dto.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(dto.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        User newUser = new User();

        newUser.Username = dto.Username;
        newUser.Password = dto.Password;
        newUser.Domain = dto.Domain;
        newUser.Email = dto.Email;
        newUser.Role = dto.Role;
        newUser.Name = dto.Name;

        userDao.CreateAsync(newUser);
        
        return Task.CompletedTask;
    }
    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}
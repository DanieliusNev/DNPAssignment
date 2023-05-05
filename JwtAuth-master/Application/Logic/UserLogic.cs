using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserRegistrationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }

    public async Task ValidateUser(UserLoginDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing == null)
            throw new Exception("Username does not exist!");
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    private static void ValidateData(UserRegistrationDto userToCreate)
    {
        string userName = userToCreate.Username;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
    
    public async Task<UserBasicDto> GetUserByName(string username)
    {
        User? user = await userDao.GetByUsernameAsync(username);
        if (user == null)
        {
            throw new Exception($"User with username: {username} not found");
        }

        return new UserBasicDto(user.Id, user.Username, user.Password, user.Email,user.Domain,user.Name, user.Role, user.Age, user.SecurityLevel);
    }
}
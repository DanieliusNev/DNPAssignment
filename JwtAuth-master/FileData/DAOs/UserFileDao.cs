
using Application.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace FileData.DAOs;

public class UserFileDao
{
} /*: IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User> RegisterAsync(UserRegistrationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            users = context.Users.Where(u => u.Username.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(users);
    }
    
    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }
    
    public Task<User> Validation(string userName, string password)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        
        if (existing == null)
        {
            throw new Exception("Username does not exist.");
        }

        if (!existing.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }
        return Task.FromResult(existing);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Id == id
        );
        return Task.FromResult(existing);
    }
}*/
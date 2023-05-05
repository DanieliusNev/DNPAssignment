using System.Security.Claims;
using Shared.Dtos;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
    Task<User> Validation(string userName, string password);
    Task<User?> GetByIdAsync(int id);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
}
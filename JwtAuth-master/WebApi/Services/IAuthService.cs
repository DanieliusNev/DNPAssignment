using Shared.Dtos;
using Shared.Models;

namespace WebApi.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(UserRegistrationDto dto);
    Task<User> GetUser(string username, string password);
}
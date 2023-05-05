using Shared.Dtos;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserRegistrationDto userToCreate);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    /*Task<User?> GetByUsernameAsync(string userName);
    Task<UserBasicDto> GetUserByName(string userName);*/
}
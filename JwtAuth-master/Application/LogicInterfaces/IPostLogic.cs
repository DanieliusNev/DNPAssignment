using Shared.Dtos;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    
    Task<PostBasicDto> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
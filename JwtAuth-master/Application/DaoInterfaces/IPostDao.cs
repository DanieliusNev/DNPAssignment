using Shared.Dtos;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    
    Task<Post?> GetByIdAsync(int postId);
    Task DeleteAsync(int id);
}
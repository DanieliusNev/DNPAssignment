using Shared.Dtos;
using Shared.Models;

namespace BlazorWasm.Services;

public interface IPostService
{
    Task CreatePostAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(
        string? userName, 
        int? userId, 
        string? title, 
        string? text
    );
    Task<PostBasicDto> GetByIdAsync(int id);
    
    Task DeleteAsync(int id);
    
}
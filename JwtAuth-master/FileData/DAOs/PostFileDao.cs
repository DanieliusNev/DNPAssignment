
using Application.DaoInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace FileData.DAOs;

public class PostFileDao
{
} /*: IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.PostId);
            id++;
        }

        post.PostId = id;
        
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParams)
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParams.Username))
        {
            // we know username is unique, so just fetch the first
            result = context.Posts.Where(todo =>
                todo.Author.Username.Equals(searchParams.Username, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParams.UserId != null)
        {
            result = result.Where(t => t.Author.Id == searchParams.UserId);
        }
        
        if (!string.IsNullOrEmpty(searchParams.Title))
        {
            result = result.Where(t =>
                t.Title.Contains(searchParams.Title, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParams.Text))
        {
            result = result.Where(t =>
                t.Title.Contains(searchParams.Text, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result);
    }
}*/
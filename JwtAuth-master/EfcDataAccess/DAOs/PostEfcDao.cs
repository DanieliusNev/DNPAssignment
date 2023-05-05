using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Dtos;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Author).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.Author.Username.ToLower().Equals(searchParameters.Username.ToLower()));
        }
    
        if (searchParameters.UserId != null)
        {
            query = query.Where(p => p.Author.Id == searchParameters.UserId);
        }
        
    
        if (!string.IsNullOrEmpty(searchParameters.Title))
        {
            query = query.Where(p =>
                p.Title.ToLower().Contains(searchParameters.Title.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
    public async Task<Post?> GetByIdAsync(int postId)
    {
        Post? found = await context.Posts
            .AsNoTracking()
            .Include(post => post.Author)
            .SingleOrDefaultAsync(post => post.PostId == postId);
        return found;
    }
    public async Task DeleteAsync(int id)
    {
        Post? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }
}
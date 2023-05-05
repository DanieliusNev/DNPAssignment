using System.Security.Cryptography;
using System.Text;
using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Dtos;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly PostContext context;

    public UserEfcDao(PostContext context)
    {
        this.context = context;
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Username.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }

    public async Task<User> Validation(string userName, string password)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Username.ToLower() == userName.ToLower()
        );
        if (existing != null)
        {
            if (existing.Password == password)
            {
                return existing;
            }
        }
    
        return null;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await context.Users.FindAsync(id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IQueryable<User> usersQuery = context.Users.AsQueryable();
        if (searchParameters.UsernameContains != null)
        {
            usersQuery = usersQuery.Where(u => u.Username.ToLower().Contains(searchParameters.UsernameContains.ToLower()));
        }

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }
    
}
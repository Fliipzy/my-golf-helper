using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using MyGolfHelper.Data;
using MyGolfHelper.Models;
using MyGolfHelper.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public class UserService : IUserService<User, long>
    {
        private readonly IDbContextFactory<MyGolfHelperDbContext> _contextFactory;

        public UserService(IDbContextFactory<MyGolfHelperDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Users.AddAsync(user);

                try
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 12);
                }
                catch (SaltParseException e)
                {
                    return null;
                }

                await context.SaveChangesAsync();
                return user;
            }
        }

        public async Task<User> FindUserAsync(long userId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .Include(user => user.Information)
                    .FirstOrDefaultAsync(u => u.Id == userId);
            }
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .Include(user => user.Information)
                    .FirstOrDefaultAsync(u => u.Information.Email == email);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .Include(user => user.Information)
                    .ToListAsync();
            }
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}

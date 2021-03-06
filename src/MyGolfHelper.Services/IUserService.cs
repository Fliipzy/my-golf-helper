using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public interface IUserService<TUser, TUserId>
    {
        Task<IEnumerable<TUser>> GetAllUsersAsync();
        Task<TUser> FindUserAsync(TUserId userId);
        Task<TUser> FindUserByEmailAsync(string email);
        Task<TUser> CreateUserAsync(TUser user);
        Task<bool> UpdateUserAsync(TUser user);
    }
}

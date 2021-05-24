using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public interface IUserService<UserType, UserIdType>
    {
        Task<IEnumerable<UserType>> GetAllUsersAsync();
        Task<UserType> FindUserAsync(UserIdType userId);
        Task<bool> UpdateUserAsync(UserType user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        public async Task<bool> VerifyUserPassword(string password, string hashedPassword)
        {
            return await Task.Run(() => BCrypt.Net.BCrypt.Verify(password, hashedPassword));
        }
    }
}

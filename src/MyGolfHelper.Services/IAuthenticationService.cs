using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services
{
    public interface IAuthenticationService
    {
        Task<bool> VerifyUserPassword(string password, string hashedPassword);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models.Dtos
{
    public class UserLoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

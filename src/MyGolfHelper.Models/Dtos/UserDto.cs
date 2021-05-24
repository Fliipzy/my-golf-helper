using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models.Dtos
{
    public sealed class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public UserInformationDto Information { get; set; }
    }
}

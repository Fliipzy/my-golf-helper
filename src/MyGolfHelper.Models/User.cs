using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGolfHelper.Models
{
    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual UserInformation Information { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}

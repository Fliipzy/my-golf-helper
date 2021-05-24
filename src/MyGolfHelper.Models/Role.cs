using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public enum RoleType : byte
    {
        [Display(Name = "User")]
        USER = 0,
        [Display(Name = "Moderator")]
        MODERATOR = 1,
        [Display(Name = "Admin")]
        ADMIN = 2
    }
    public class Role
    {
        public long Id { get; set; }
        public RoleType Type { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}

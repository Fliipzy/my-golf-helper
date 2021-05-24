using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class GolfClub : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<GolfCourse> Courses { get; set; }
    }
}

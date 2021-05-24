using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class GolfCourse : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Par { get; set; }

        public virtual GolfCourseRating Ratings { get; set; }
        public virtual ICollection<GolfHole> Holes { get; set; }
        public long ClubId { get; set; }
        public virtual GolfClub Club { get; set; }
    }
}

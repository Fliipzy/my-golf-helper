using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class GolfHoleHazard : BaseEntity
    {
        public long GolfHoleId { get; set; }
        public virtual GolfHole GolfHole { get; set; }

        public long HazardId { get; set; }
        public virtual Hazard Hazard { get; set; }
    }
}

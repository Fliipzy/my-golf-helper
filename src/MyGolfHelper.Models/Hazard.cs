using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class Hazard
    {
        public long Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<GolfHoleHazard> GolfHoleHazards { get; set; }
    }
}

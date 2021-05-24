using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class Hazard
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<GolfHoleHazard> GolfHoleHazards { get; set; }
    }
}

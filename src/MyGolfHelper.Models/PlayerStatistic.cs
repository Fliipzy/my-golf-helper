using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class PlayerStatistic : BaseEntity
    {
        public float Handicap { get; set; }
        public int RoundsPlayedTotal { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}

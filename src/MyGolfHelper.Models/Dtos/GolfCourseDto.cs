using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models.Dtos
{
    public class GolfCourseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Par { get; set; }
        public long ClubId { get; set; }
    }
}

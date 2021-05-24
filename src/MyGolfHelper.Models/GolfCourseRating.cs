using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class GolfCourseRating : BaseEntity
    {
        public float MenWhiteCourse { get; set; }
        public float MenWhiteSlope { get; set; }
        public float MenYellowCourse { get; set; }
        public float MenYellowSlope { get; set; }
        public float MenRedCourse { get; set; }
        public float MenRedSlope { get; set; }
        public float WomenWhiteCourse { get; set; }
        public float WomenWhiteSlope { get; set; }
        public float WomenYellowCourse { get; set; }
        public float WomenYellowSlope { get; set; }
        public float WomenRedCourse { get; set; }
        public float WomenRedSlope { get; set; }

        public long GolfCourseId { get; set; }
        public virtual GolfCourse GolfCourse { get; set; }
    }
}

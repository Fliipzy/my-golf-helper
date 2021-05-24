﻿using System;
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

        public virtual ICollection<GolfCourse> Courses { get; set; }
    }
}

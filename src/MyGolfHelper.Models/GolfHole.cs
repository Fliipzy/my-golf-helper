﻿using System.Collections.Generic;

namespace MyGolfHelper.Models
{
    public class GolfHole : BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Par { get; set; }
        public int BlueTeeLength { get; set; }
        public int WhiteTeeLength { get; set; }
        public int YellowTeeLength { get; set; }
        public int RedTeeLength { get; set; }

        public virtual ICollection<GolfHoleHazard> Hazards { get; set; }
    }
}
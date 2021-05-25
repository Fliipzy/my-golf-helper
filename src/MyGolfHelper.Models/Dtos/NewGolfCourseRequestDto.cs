using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models.Dtos
{
    public class NewGolfCourseRequestDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public long ClubId { get; set; }
    }
}

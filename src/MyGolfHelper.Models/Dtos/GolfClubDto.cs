using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models.Dtos
{
    public class GolfClubDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AddressId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Models
{
    public class Address : BaseEntity
    {
        public long Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string State { get; set; }

        public virtual GolfClub Club { get; set; }
    }
}

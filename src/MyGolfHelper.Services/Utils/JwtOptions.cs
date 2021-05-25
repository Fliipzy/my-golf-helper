using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGolfHelper.Services.Utils
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public long ExpiresInSeconds { get; set; }
    }
}

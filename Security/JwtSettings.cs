using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Security
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Source { get; set; }
        public string Validation { get; set; }

    }
}

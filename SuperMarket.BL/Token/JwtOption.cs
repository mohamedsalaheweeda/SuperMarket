using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DL
{
    public class JwtOption
    {
      
        public string Issuer { get; set; }=string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int DurationInDays { get; set; }
        public string SigningKey { get; set; } = string.Empty;
    }

}

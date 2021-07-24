using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamz.Domain.Security
{
    public class RefreshToken
    {
        public string RefreshId { get; set; }
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }
    }
}

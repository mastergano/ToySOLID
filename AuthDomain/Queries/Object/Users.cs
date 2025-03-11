using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries.Object
{
    public class Users :IQuery
    {
        public string Login { get; set; } = null!;
        public IEnumerable<string> Rules { get; set; } = null!;
    }
}

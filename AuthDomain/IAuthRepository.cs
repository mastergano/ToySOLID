using AuthDomain.Queries.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain
{
    public interface IAuthRepository
    {
        Users? Registration(string login, string password, string avatar);
        Users? Authorization(string login, string password);
    }
}

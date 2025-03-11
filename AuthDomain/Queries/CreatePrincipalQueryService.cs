using AuthDomain.Queries.Object;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries
{
    public class CreatePrincipalQueryService : IQueryService<Users, ClaimsPrincipal>
    {
        public ClaimsPrincipal Execute(Users obj)
        {
            List<Claim> claims = new List<Claim>();
            foreach(var name in obj.Rules)
            {
                claims.Add(new Claim("role", name));
            }
            var identity = new ClaimsIdentity(claims,
                                             "RulesClaim",
                                             ClaimTypes.Name,
                                             ClaimTypes.Role);
            return new ClaimsPrincipal(identity);
        }
    }
}

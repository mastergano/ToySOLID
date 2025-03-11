using AuthDomain;
using AuthDomain.Queries.Object;
using Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AuthRepository : IAuthRepository
    {

        private readonly Connection _connection;

        public AuthRepository(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);
            _connection = connection;
        }

        public Users? Authorization(string login, string password)
        {
            var client = _connection.Users
                                    .AsNoTracking()
                                    .Include(row => row.Roles)
                                    .FirstOrDefault(row =>
                                    row.Login.ToLower() == login.ToLower()
                                    && row.Password == password);

            if(client!=null)
            {
                Users user = new Users();
                user.Login = login;
                user.Rules = client.Roles.Select(row => row.Value).ToList();
                return user;
            }
            return null;

        }

        public Users? Registration(string login, string password, string avatar)
        {
            bool any = _connection.Users
                                .Any(row => row.Login.ToLower() == login.ToLower());
            if (!any)
            {
                User row = new User();
                row.Login = login.ToLower();
                row.Password = password;
                row.avatar = avatar;
                var role = _connection.Roles.AsNoTracking().FirstOrDefault(row => row.Value == "User");
                row.Roles = new List<Role>() { role };
                _connection.Add(row);
                if (_connection.SaveChanges() > 0)
                {
                    Users user = new Users();
                    user.Login = login;
                    user.Rules = new List<string>() { role.Value };
                    return user;
                }
            }
            return null;
        }
    }
}

using Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Connection :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ToyImage> ToyImages { get; set; }
        public DbSet<Toy> Toys { get; set; }

        public Connection(DbContextOptions<Connection> options) :base(options)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebNetCore2.Models
{
    public class MySqlDbContext : DbContext
    {
        //http://insidemysql.com/howto-starting-with-mysql-ef-core-provider-and-connectornet-7-0-4/

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
        : base(options)
        { }

        public DbSet<Users> users { get; set; }       

    }
}

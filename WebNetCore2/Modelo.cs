using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebNetCore2
{
    public class MyOptions
    {
        public MyOptions()
        {

        }

        public string ConStr { get; set; }
    }

    //http://insidemysql.com/howto-starting-with-mysql-ef-core-provider-and-connectornet-7-0-4/

    /// <summary>
    /// The entity framework context with a Employees DbSet
    /// </summary>
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
        { }

        public DbSet<locations> locations { get; set; }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class SampleContextFactory
    {
        public static SampleDbContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();
            optionsBuilder.UseMySql(connectionString);

            //Ensure database creation
            var context = new SampleDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }

    /// <summary>
    /// A basic class for an Employee
    /// </summary>
    public class locations
    {
        public locations()
        {
        }

        public int Id { get; set; }


    }
}

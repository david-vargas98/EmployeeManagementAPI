using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class AppDBContext : DbContext // DBContext has the methods to add, update, deleter and query data
    {
        //The constructor allows us to register our AppDBContext inside of Program.cs as a service (dependency injection)
        public AppDBContext(DbContextOptions<AppDBContext> options) // this receives options from the Program.cs file (configuration on how to connect to the database)
            : base(options) // this passes the options to the base DbContext class
        {
        }
    }
}

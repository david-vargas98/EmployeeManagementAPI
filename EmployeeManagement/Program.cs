using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // This registers and configures the AppDBContext as a service to the application
            builder.Services.AddDbContext<AppDBContext>( // adds a context AppDBContext which receives the constructor as DbContextOptions<AppDBContext>
                options => options.UseInMemoryDatabase("EmployeeDB") // arrow function to say that DB is in memory and named "EmployeeDB"
            );

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}

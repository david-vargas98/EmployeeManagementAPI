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

            // Creating CORS policy to allow requests from our Angular app
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Allow requests form our Angular app
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Using the CORS policy we created above
            app.UseCors("MyCors");

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}

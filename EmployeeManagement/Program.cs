using EmployeeManagement.Data;
using EmployeeManagement.Repositories;
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

            // - Registering the repository and its class implementation as a service to the Dependency Injection (DI) container
            // - For each HTTP request, a new instance of EmployeeRepository will be created and when the HTTP request is done, the instance will get disposed
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Enabling controllers
            builder.Services.AddControllers();

            // Enables and creates the inner model for Swagger by finding the controllers and their endpoints
            builder.Services.AddEndpointsApiExplorer();

            // Takes the model above and generates the Swagger documentation and UI
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger is only intented for development environment, so we check if we are in development environment
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Registers the Swagger middleware
                app.UseSwaggerUI(config => // Provide us with an interactive UI to test the endpoints
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); // The endpoint where the Swagger JSON is generated
                }); 
            }

            // Using the CORS policy we created above
            app.UseCors("MyCors");

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}

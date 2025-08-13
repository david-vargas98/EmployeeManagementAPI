using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _context; // Private field to make AppDBContext accessible within the class
        public EmployeeRepository(AppDBContext context) // Constructor that receives the AppDBContext instance from dependency injection on Program.cs
        {
            _context = context; // Readonly only allows us to initialize the field here in the constructor (just once)
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            // We use async to allow the method to run asynchronously and await keyword to wait for the operation to complete without blocking the thread
            await _context.Employees.AddAsync(employee); // Adds the employee to the Employees DbSet in memory
            await _context.SaveChangesAsync(); // Saves the changes to the database asynchronously
        }
    }
}

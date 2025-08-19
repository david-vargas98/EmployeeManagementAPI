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

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync(); // Retrieves all employees from the Employees DbSet asynchronously
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        // For updating and deleting methods we don't have the async versions
        // We keep async keyword and then in SaaveChangesAsync we await the changes to be saved
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee); // No uptade method in EF Core, it's not necessary since we only change the entity's state to modified in memory
            await _context.SaveChangesAsync();   // so, it has no sense for update method to have an async version, since it doesn't do any I/O DB operation
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employeeInDb = await _context.Employees.FindAsync(id);

            if(employeeInDb == null)
                throw new KeyNotFoundException($"Employee with ID {id} was not found.");

            _context.Employees.Remove(employeeInDb); // The same as Update, it's just a memory operation, it changes the state to "Deleted" in changes tracker

            await _context.SaveChangesAsync();
        }
    }
}

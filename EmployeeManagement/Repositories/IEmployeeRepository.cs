using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    //By creating interfaces we guarantee that classes will implement the methods defined in the interface
    public interface IEmployeeRepository
    {
        // Task is a generic object of type IEnumerable<Employee>, Employee, etc., For asynchronous operations
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);

    }
}

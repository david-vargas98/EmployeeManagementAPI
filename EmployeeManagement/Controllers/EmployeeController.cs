using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")] // i.e. api/employee
    [ApiController] // enables features such as automatic model validation, binding, etc.
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository; // we use an interface to allow for easier testing and mocking

        // We use the Interface to access the repository methods to decouple the controller from the repository implementation
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository; // we inject the repository through the constructor
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
        {
            // it could be simplyfied to return allEmployees directly without the variable but for the sake of clarity we use a variable
            
            var allEmployees = await _employeeRepository.GetAllAsync(); // Retrieves all employees asynchronously

            return Ok(allEmployees); // Returns a 200 OK status code with the list of employees

        }

        // We need to specify for our route that we expect an ID in the URL
        [HttpGet("{id}")] // i.e. api/employee/1
        public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound(); // Returns a 404 Not Found status code

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);

            return Created(); // Returns a 201 Created status code
        }
    }
}

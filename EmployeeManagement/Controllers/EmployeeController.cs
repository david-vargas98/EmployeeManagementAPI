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
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);

            return Created(); // Returns a 201 Created status code
        }
    }
}

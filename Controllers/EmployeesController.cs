using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Employee.Models;
using POC_Employee.Repository;

namespace POC_Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewEmployee([FromBody]EmployeeModel employeeModel)
        {
            var id = await _employeeRepository.AddEmployeeAsync(employeeModel);
            return CreatedAtAction(nameof(GetEmployeeById), new {id=id, controller="employees"}, id);
        }
    }
}

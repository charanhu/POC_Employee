using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        
        // Get All employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get employees by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int id)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add new Employee
        [HttpPost]
        public async Task<IActionResult> AddNewEmployee([FromBody]EmployeeModel employeeModel)
        {
            try
            {
                var id = await _employeeRepository.AddEmployeeAsync(employeeModel);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = id, controller = "employees" }, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update Employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeModel employeeModel)
        {
            try
            {
                await _employeeRepository.UpdateEmployeeAsync(id, employeeModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmployeePatch([FromRoute] int id, [FromBody] JsonPatchDocument employeeModel)
        {
            try
            {
                await _employeeRepository.UpdateEmployeePatchAsync(id, employeeModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete Employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteeEmployee([FromRoute] int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

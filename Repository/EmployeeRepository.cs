using Microsoft.EntityFrameworkCore;
using POC_Employee.Data;
using POC_Employee.Models;

namespace POC_Employee.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var records = await _context.Employees.Select(x=> new EmployeeModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Address = x.Address,
                City = x.City,
                StateCode = x.StateCode,
                ZipCode = x.ZipCode,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Salary = x.Salary,  
                DepartmentId = x.DepartmentId
            }).ToListAsync();
            return records;
        }
    }
}

using POC_Employee.Models;

namespace POC_Employee.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId);
        Task<int> AddEmployeeAsync(EmployeeModel employeeModel);
        Task UpdateEmployeeAsync(int employeeId, EmployeeModel employeeModel);
    }
}

using POC_Employee.Models;

namespace POC_Employee.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
    }
}

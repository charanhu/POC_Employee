using AutoMapper;
using POC_Employee.Data;
using POC_Employee.Models;

namespace POC_Employee.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Employees, EmployeeModel>().ReverseMap();
        }
    }
}

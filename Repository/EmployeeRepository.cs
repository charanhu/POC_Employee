﻿using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId)
        {
            var records = await _context.Employees.Where(x => x.Id == employeeId).Select(x => new EmployeeModel()
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
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddEmployeeAsync(EmployeeModel employeeModel)
        {
            var employee = new Employees()
            {
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                DateOfBirth = employeeModel.DateOfBirth,
                Address = employeeModel.Address,
                City = employeeModel.City,
                StateCode = employeeModel.StateCode,
                ZipCode = employeeModel.ZipCode,
                PhoneNumber = employeeModel.PhoneNumber,
                Email = employeeModel.Email,
                Salary = employeeModel.Salary,
                DepartmentId = employeeModel.DepartmentId
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }
        public async Task UpdateEmployeeAsync(int employeeId, EmployeeModel employeeModel)
        {
            //var employee = await _context.Employees.FindAsync(employeeId);
            //if(employee != null)
            //{
            //    employee.FirstName=employeeModel.FirstName;
            //    employee.LastName=employeeModel.LastName;
            //    employee.DateOfBirth=employeeModel.DateOfBirth;
            //    employee.Address=employeeModel.Address;
            //    employee.City=employeeModel.City;
            //    employee.StateCode=employeeModel.StateCode;
            //    employee.ZipCode=employeeModel.ZipCode;
            //    employee.PhoneNumber=employeeModel.PhoneNumber;
            //    employee.Email=employeeModel.Email;
            //    employee.Salary=employeeModel.Salary;
            //    employee.DepartmentId=employeeModel.DepartmentId;

            //    await _context.SaveChangesAsync();
            //}
            // the above code hits database two times


            var employee = new Employees()
            {
                Id = employeeId,
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                DateOfBirth = employeeModel.DateOfBirth,
                Address = employeeModel.Address,
                City = employeeModel.City,
                StateCode = employeeModel.StateCode,
                ZipCode = employeeModel.ZipCode,
                PhoneNumber = employeeModel.PhoneNumber,
                Email = employeeModel.Email,
                Salary = employeeModel.Salary,
                DepartmentId = employeeModel.DepartmentId
            };
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEmployeePatchAsync(int employeeId, JsonPatchDocument employeeModel)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if(employee!= null)
            {
                employeeModel.ApplyTo(employee);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = new Employees() { Id = employeeId };
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

    }
}

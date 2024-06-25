﻿using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Contracts.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int employeeId);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);

        Task DeleteEmployee(int employeeId);
    }
}

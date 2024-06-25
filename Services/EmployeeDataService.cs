using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PieShopHRM.Contracts.Repositories;
using PieShopHRM.Contracts.Services;
using PieShopHRM.Repositories;
using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private IEmployeeRepository _employeeRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeDataService(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _employeeRepository.GetEmployeeById(employeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _employeeRepository.AddEmployee(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            if (employee.ImageContent != null)
            {
                string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
                var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
                var fileStream = System.IO.File.Create(path);
                fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
                fileStream.Close();

                employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";
            }

            await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
        }
    }
}

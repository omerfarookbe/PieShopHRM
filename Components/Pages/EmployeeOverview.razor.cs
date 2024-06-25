using Microsoft.AspNetCore.Components;
using PieShopHRM.Contracts.Services;
using PieShopHRM.Services;
using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Components.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;

        private Employee _selectedEmployee;

        [Inject] 
        public IEmployeeDataService? EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}

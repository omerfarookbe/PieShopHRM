using Microsoft.AspNetCore.Components;
using PieShopHRM.Contracts.Services;
using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Components.Pages
{
    public partial class EmployeeAdd
    {
        [SupplyParameterFromForm]
        public Employee employee { get; set; }

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        bool IsSaved = false;
        string Message = string.Empty;
        protected override void OnInitialized()
        {
            employee ??= new();
        }

        private async Task OnSubmit()
        {
            await EmployeeDataService.AddEmployee(employee);
            IsSaved=true;
            Message = "Employee added successfully";
        }
    }
}

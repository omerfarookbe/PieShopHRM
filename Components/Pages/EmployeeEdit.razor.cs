using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PieShopHRM.Contracts.Services;
using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Components.Pages
{
    public partial class EmployeeEdit
    {
        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService? CountryDataService { get; set; }

        [Inject]
        public IJobCategoryDataService? JobCategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigateManager { get; set; }

        [Parameter]
        public int EmployeeId { get; set; }

        [SupplyParameterFromForm]
        public Employee employee { get; set; } = new();

        public List<Country> Countries { get; set; } = [];
        public List<JobCategory> JobCategories { get; set; } = [];

        protected bool Saved;

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            employee = await EmployeeDataService.GetEmployeeById(EmployeeId);
        }

        private IBrowserFile selectedFile;
        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            if (selectedFile != null)//take first image
            {
                var file = selectedFile;
                Stream stream = file.OpenReadStream();
                MemoryStream ms = new();
                await stream.CopyToAsync(ms);
                stream.Close();

                employee.ImageName = file.Name;
                employee.ImageContent = ms.ToArray();
            }

            await EmployeeDataService.UpdateEmployee(employee);
            Saved = true;
            StatusClass = "alert-success";
            Message = "Employee updated successfully";
        }

        protected async Task HandleInValidSubmit()
        {
            StatusClass = "alert-anger";
            Message = "Validation errors. Please correct it and try again";
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(employee.EmployeeId);
            Saved = true;
            StatusClass = "alert-success";
            Message = "Employee deleted successfully";
        }

        protected async Task NavigateToOverview()
        {
            NavigateManager.NavigateTo("/employeeoverview");
        }
    }
}

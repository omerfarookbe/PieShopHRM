using PieShopHRM.Shared.Domain;

namespace PieShopHRM.Contracts.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}

using Covid19Chart.API.Models;

namespace Covid19Chart.API.Services
{
    public interface ICovidService
    {
        Task AddCovid(Covid covid);
        IQueryable<Covid> GetCovids();
        Task<IList<Country>> GetCountries();
    }
}

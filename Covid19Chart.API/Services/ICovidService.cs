using Covid19Chart.API.Models;
using Covid19Chart.API.ViewModels;

namespace Covid19Chart.API.Services
{
    public interface ICovidService
    {
        Task AddCovid(Covid covid);
        IQueryable<Covid> GetCovids();
        Task<IList<Country>> GetCountries();
        List<CovidChart> GetCovidChartList();
        List<CovidChart> GetCovidChartListByCountryId(int id);
        List<CovidChart> GetCovidDeathCountListByCountryId(int id);
    }
}

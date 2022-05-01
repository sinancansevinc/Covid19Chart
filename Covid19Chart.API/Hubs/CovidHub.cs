using Covid19Chart.API.Services;
using Microsoft.AspNetCore.SignalR;

namespace Covid19Chart.API.Hubs
{
    public class CovidHub:Hub
    {
        private readonly ICovidService _covidService;

        public CovidHub(ICovidService covidService)
        {
            _covidService = covidService;
        }

        public async Task GetCovidList()
        {
            await Clients.All.SendAsync("ReceiveCovid",_covidService.GetCovidChartList());
        }
        public async Task GetStartCovidList(int id)
        {
            await Clients.All.SendAsync("ReceiveStartCovid", _covidService.GetCovidChartListByCountryId(id));
        }
        public async Task GetCovidDeathCountList(int id)
        {
            await Clients.All.SendAsync("ReceiveDeathCovid", _covidService.GetCovidDeathCountListByCountryId(id));

        }
    }
}

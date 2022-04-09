using Microsoft.AspNetCore.SignalR;

namespace Covid19Chart.API.Hubs
{
    public class CovidHub:Hub
    {
        public async Task GetList()
        {
            await Clients.All.SendAsync("ReceiveCovid","Datas");
        }
    }
}

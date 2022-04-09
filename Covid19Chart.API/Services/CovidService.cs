using Covid19Chart.API.Context;
using Covid19Chart.API.Hubs;
using Covid19Chart.API.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Covid19Chart.API.Services
{
    public class CovidService : ICovidService
    {
        private readonly DatabaseContext _context;
        private readonly IHubContext<CovidHub> _hubContext;

        public CovidService(DatabaseContext context, IHubContext<CovidHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task AddCovid(Covid covid)
        {

            await _context.AddAsync(covid);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveCovid","data");


        }

        public async Task<IList<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public IQueryable<Covid> GetCovids()
        {
            return _context.Covids.AsQueryable();
        }
    }
}

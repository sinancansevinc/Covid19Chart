using Covid19Chart.API.Models;
using Covid19Chart.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Covid19Chart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidsController : ControllerBase
    {
        private readonly ICovidService _covidService;

        public CovidsController(ICovidService covidService)
        {
            _covidService = covidService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCovid(Covid covid)
        {
            try
            {
                await _covidService.AddCovid(covid);
                IQueryable<Covid> covids = _covidService.GetCovids();
                return Ok(covids);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }

        
        [HttpGet]
        public async Task<IActionResult> SaveRandomData()
        {
            Random rand = new Random();
            IList<Country> countries =await _covidService.GetCountries();
            Enumerable.Range(1, 10).ToList().ForEach(i =>
             {
                 foreach (var country in countries)
                 {
                     var newCovid = new Covid()
                     {
                         CountryId = country.Id,
                         Count = rand.Next(100, 1000),
                         CovidDate = DateTime.Now.AddDays(i)
                     };

                     //Wait for the service to save the data
                     _covidService.AddCovid(newCovid).Wait();
                     Thread.Sleep(1000);
                 }
                
             });


            return Ok("Covid data saved on database");


        }
    }
}

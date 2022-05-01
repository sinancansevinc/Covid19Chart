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
                //IQueryable<Covid> covids = _covidService.GetCovids();
                return Ok(_covidService.GetCovidChartListByCountryId(covid.CountryId));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }

        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _covidService.GetCountries();
                return Ok(countries);
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
            IList<Country> countries = await _covidService.GetCountries();

            try
            {
                Enumerable.Range(1, 10).ToList().ForEach(i =>
                 {
                     foreach (var country in countries)
                     {
                         var newCovid = new Covid()
                         {
                             CountryId = country.Id,
                             CaseCount = rand.Next(10000, 20000),
                             DeathCount = rand.Next(120, 240),
                             RecoverCount = rand.Next(9000, 18000),
                             CovidDate = DateTime.Now.AddDays(i)
                         };

                     //Wait for the service to save the data
                     _covidService.AddCovid(newCovid).Wait();
                         Thread.Sleep(1000);
                     }

                 });

            }
            catch (Exception)
            {

                return BadRequest();
            }


            return Ok("Covid data saved on database");


        }

        [HttpGet("GetCovidListByCountryId")]
        public IActionResult GetCovidListByCountryId(int countryId)
        {
            try
            {
                return Ok(_covidService.GetCovidChartListByCountryId(countryId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}

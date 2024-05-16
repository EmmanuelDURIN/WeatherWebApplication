using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;

namespace WeatherWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase, IDisposable
    {
        private IMeteoComputer meteoComputer;
        public WeatherForecastController(IMeteoComputer meteoComputer,
            ILogger<WeatherForecastController> logger)
        {
            this.meteoComputer = meteoComputer;
            _logger = logger;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("dynamic", Name = "GetNDaysWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(int forecastDays)
        {
            return Enumerable.Range(1, forecastDays).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost()]
        //public IActionResult Retrieve([FromQuery]WeatherForecast weatherForecast)
        public IActionResult Post([FromBody] WeatherForecast weatherForecast)
        {
            // Business validation
            if (!meteoComputer.Validate())
            {
                // 400
                //return BadRequest();
                this.ModelState.AddModelError("field1", "Super error msg");
                this.ModelState.AddModelError("field1", "Super error msg2");
                this.ModelState.AddModelError("field2", "Great error msg");
                return ValidationProblem(ModelState);
            }
            meteoComputer.Acquire();
            return Created();
        }
        public void Dispose()
        {
        }
    }
}

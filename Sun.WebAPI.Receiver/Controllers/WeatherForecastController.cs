using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sun.WebAPI.Receiver.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.WebAPI.Receiver.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public LocationInfo WeatherPost(LocationInfo locationInfo)
        {
            locationInfo.Message = $"Received @ {DateTime.Now}";
            return locationInfo;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }

    public class LocationInfo
    {
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Message { get; set; }
    }
}

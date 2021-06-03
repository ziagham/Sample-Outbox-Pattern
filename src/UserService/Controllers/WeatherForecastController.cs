using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events.Users;
using Infrastructure.Core.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEventBus _eventBus;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            _eventBus.Commit(new UserCreatedEvent {
                UserId = Guid.NewGuid(),
                FirstName = "Amin",
                LastName = "Ziagham",
                Email = "amin.ziagham@gmail.com"
            });
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AspNetv3EFCoreInMemory.API.Models;
using AspNetv3EFCoreInMemory.API.Interfaces;

namespace AspNetv3EFCoreInMemory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly ILogger _logger;
        public WeatherForecastController(IWeatherForecastRepository weatherForecastRepository, ILogger logger)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet]
        public ActionResult<List<WeatherForecast>> GetWeatherForecast()
        {
            _logger.LogInformation("Buscando lista da controller");
            return Ok(_weatherForecastRepository.GetWeatherForecasts());
        }
    }
}

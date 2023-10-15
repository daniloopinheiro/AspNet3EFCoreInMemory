using System.Collections.Generic;
using System.Linq;
using AspNetv3EFCoreInMemory.API.Data;
using AspNetv3EFCoreInMemory.API.Interfaces;
using AspNetv3EFCoreInMemory.API.Models;

namespace AspNetv3EFCoreInMemory.API.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApiContext _apiContext;

        public WeatherForecastRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return _apiContext.WeatherForecasts.ToList();
        }
    }
}
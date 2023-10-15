using System.Collections.Generic;
using AspNetv3EFCoreInMemory.API.Models;

namespace AspNetv3EFCoreInMemory.API.Interfaces
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }      
}
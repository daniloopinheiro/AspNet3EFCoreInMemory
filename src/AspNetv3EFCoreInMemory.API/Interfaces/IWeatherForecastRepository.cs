using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetv3EFCoreInMemory.API.Models;

namespace AspNetv3EFCoreInMemory.API.Interfaces
{
    public interface IWeatherForecastRepository
    {
        public WeatherForecast GetWeatherForecasts();
    }      
}
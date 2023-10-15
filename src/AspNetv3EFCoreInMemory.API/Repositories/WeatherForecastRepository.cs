using System;
using System.Collections.Generic;
using System.Linq;
using AspNetv3EFCoreInMemory.API.Data;
using AspNetv3EFCoreInMemory.API.Interfaces;
using AspNetv3EFCoreInMemory.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AspNetv3EFCoreInMemory.API.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApiContext _apiContext;

        public WeatherForecastRepository(ApiContext apiContext, MemoryCache memoryCache)
        {
            _apiContext = apiContext;
        }

         private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecast GetWeatherForecasts()
        {
            var rng = new Random();

            var result = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-10, 100),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };

            _apiContext.WeatherForecasts.Add(result);
            _apiContext.SaveChanges();

            return new WeatherForecast();
        }
    }
}
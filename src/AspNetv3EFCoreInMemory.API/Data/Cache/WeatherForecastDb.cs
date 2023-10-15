using System;
using System.Collections.Generic;
using System.Linq;
using AspNetv3EFCoreInMemory.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetv3EFCoreInMemory.API.Data.Cache
{
    public static class WeatherForecastDb
    {
        //private static readonly ILogger _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static void WeatherForecastBuilder(IApplicationBuilder app)
        {
            using (var serviceScop = app.ApplicationServices.CreateScope())
            {
                WeatherForecastData(serviceScop.ServiceProvider.GetService<ApiContext>());
            }
        }

        private static void WeatherForecastData(ApiContext context)
        {

            if (!context.WeatherForecasts.Any())
            {
                var rng = new Random();
                Console.WriteLine("--> Inserção de dados inicializado <--");
                //_logger.LogInformation("--> Inserção de dados inicializado <--");

                object value = Enumerable.Range(1, 6).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToArray();

                context.WeatherForecasts.AddRange((IEnumerable<WeatherForecast>)value);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já constam dados na base. <--");
                //_logger.LogInformation("--> Já constam dados na base. <--");
            }
        }
    }
}
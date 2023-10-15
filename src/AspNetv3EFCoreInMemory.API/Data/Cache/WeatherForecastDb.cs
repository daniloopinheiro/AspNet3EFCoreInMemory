using System;
using System.Linq;
using AspNetv3EFCoreInMemory.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetv3EFCoreInMemory.API.Data.Cache
{
    public static class WeatherForecastDb
    {
        // private static readonly ILogger _logger;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static void WeatherForecastBuilder(IApplicationBuilder app)
        {
            using(var serviceScop = app.ApplicationServices.CreateScope())
            {
                WeatherForecastData(serviceScop.ServiceProvider.GetService<ApiContext>());
            }
        }

        private static void WeatherForecastData(ApiContext context)
        {
            try
            {
                if(!context.WeatherForecasts.Any())
                {
                    var rng = new Random();

                    Console.WriteLine("--> Inserção de dados inicializado <--");
                    // _logger.LogInformation("");
                    
                    context.WeatherForecasts.Select(Index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(90),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    }).ToArray();

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("--> Já constam dados na base. <--");
                    // _logger.LogInformation("");
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message, "--> Houve algum erro ao detectar dados, ou inseri-lo. <--");
                // _logger.LogError(ex, "--> Houve algum erro ao detectar dados, ou inseri-lo. <--");
            }
            
        }
    }
}
using Microsoft.EntityFrameworkCore;
using AspNetv3EFCoreInMemory.API.Models;
using System;

namespace AspNetv3EFCoreInMemory.API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {}

        public DbSet<WeatherForecast> WeatherForecasts {get; set;}
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.DBContexts
{
    public class TrackerDbContext:DbContext
    {
        public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set;}

    }
}

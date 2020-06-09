using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Concrete.Service
{
    public class WeatherRepository : IWeatherRepository
    {

        private readonly TrackerDbContext _trackerDbContext;
        private readonly ILogger<WeatherRepository> logger;
        private readonly IMapper mapper;

        public WeatherRepository(TrackerDbContext trackerDbContext, ILogger<WeatherRepository> logger, IMapper mapper)
        {
            _trackerDbContext = trackerDbContext;
            this.logger = logger;
            this.mapper = mapper;


        }

        public Microsoft.AspNetCore.Mvc.IActionResult DeleteWeather(int WeatherId)
        {
            var weather = _trackerDbContext.WeatherForecasts.Find(WeatherId);
            if (weather != null)
            {
                _trackerDbContext.WeatherForecasts.Remove(weather);
                Save();
                return new OkResult();
            }
            return new NotFoundResult();
        }

        public Models.Models.WeatherForecast GetWeatherForecastByID(int WeatherId)
        {
            var weather = _trackerDbContext.WeatherForecasts.Find(WeatherId);
            if (weather != null)
            {
                var result=mapper.Map<Models.Models.WeatherForecast>(weather);
                return result;
            }
            return null;

        }

        public IEnumerable<Models.Models.WeatherForecast> GetWeatherForecasts()
        {
            try
            {
                Console.WriteLine("before try....");
                var weather = _trackerDbContext.WeatherForecasts;
                if (weather != null && weather.Any())
                {
                    Console.WriteLine("Here");
                    var result = mapper.Map<IEnumerable<Models.Models.WeatherForecast>>(weather);
                    Console.WriteLine(result.Count());
                    return  result;
                }
                return null;
            }
            catch (Exception e)
            {
                logger?.LogError(e.ToString());
                return  null;
            }
        }

        
         public void InsertWeather(Models.Models.WeatherForecast weatherForecast)
        {
            var insertWeather=mapper.Map<Models.DBContexts.WeatherForecast>(weatherForecast);
            _trackerDbContext.Add(insertWeather);
            Save();
        }


        
        public void UpdateWeather(Models.Models.WeatherForecast weatherForecast)
        {
            var updateWeather = mapper.Map<Models.DBContexts.WeatherForecast>(weatherForecast);
            _trackerDbContext.Entry(updateWeather).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _trackerDbContext.SaveChanges();
        }

    } 
}


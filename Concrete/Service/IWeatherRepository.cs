
using Microsoft.AspNetCore.Mvc;
using System;
using Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Concrete.Service
{
    public interface IWeatherRepository
    {

        IEnumerable<WeatherForecast> GetWeatherForecasts();
        WeatherForecast GetWeatherForecastByID(int WeatherId);
        void InsertWeather(WeatherForecast weatherForecast);
        IActionResult DeleteWeather(int WeatherId);
        void UpdateWeather(WeatherForecast weatherForecast);
        void Save(); 
    }
}

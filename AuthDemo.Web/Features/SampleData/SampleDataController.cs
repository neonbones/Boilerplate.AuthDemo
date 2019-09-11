using System;
using System.Collections.Generic;
using System.Linq;
using AuthDemo.Web.Controllers.Administrator;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Web.Features.SampleData
{
    public class SampleDataController : AdministratorApiController
    {
        private static readonly string[] Summaries = 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rnd = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rnd.Next(-20, 55),
                Summary = Summaries[rnd.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
        }
    }
}

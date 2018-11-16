using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherApp.Respository
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetCurrentWeatherAsync(string cityName);
    }
}

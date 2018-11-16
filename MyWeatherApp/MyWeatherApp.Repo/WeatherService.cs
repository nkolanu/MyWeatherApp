using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherApp.Respository
{
    public class WeatherService : IWeatherService
    {
        string weatherURL = "https://api.openweathermap.org/data/2.5/weather?q={0}&apikey=268cffd002c8041c96895f23d52cc79d";

        public async Task<WeatherModel> GetCurrentWeatherAsync(string cityName)
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync(string.Format(weatherURL, cityName));

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<WeatherModel>(content);

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

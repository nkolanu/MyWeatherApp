using MyWeatherApp.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWeatherApp
{
    public partial class MainPage : ContentPage
    {
        IWeatherService weatherService;

        public MainPage()
        {
            InitializeComponent();

            if (weatherService == null)
                weatherService = new WeatherService();

        }

        private async void GetWeather_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlert("MyWeatherApp", "Looking for weather for: " + cityName.Text, "OK");

            var weather = await weatherService.GetCurrentWeatherAsync(cityName.Text);

            if (weather == null)
            {
                await DisplayAlert("MyWeatherApp", "Could not get weather, Please check the City Name", "OK");
                return;
            }
            if (weather.main == null)
            {
                await DisplayAlert("MyWeatherApp", "Could not get weather, Please try again", "OK");
                return;
            }
            cityTemp.Text = weather.main.temp.ToString();
        }
    }
}

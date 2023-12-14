using ASp_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using ASp_MVC.Services;

namespace MyAppMVC.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly IWeatherService _weatherService;

        public WeatherViewComponent(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public async Task<IViewComponentResult> InvokeAsync(Coord coord)
        {
            WeatherData weather = await _weatherService.GetWeatherAsync(coord.latitude, coord.longitude);
            return View(weather);
        }
    }
}

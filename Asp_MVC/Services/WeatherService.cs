using ASp_MVC.Models;
using Newtonsoft.Json;

namespace ASp_MVC.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(double latitude, double longitude);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude)
        {
            try
            {
                var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={_configuration.GetSection("ApiWeatherKey").Value}";

                var response = await _httpClient.GetStringAsync(apiUrl);

                var weatherData = JsonConvert.DeserializeObject<WeatherData>(response);

                return weatherData;
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    
    }
}

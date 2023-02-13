using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeartherStateBLL.Interfaces;
using WeartherStateBLL.Models;
using WeartherStateBLL.Options;
using WeartherStateBLL.Utils;

namespace WeartherStateBLL.Services
{
    public class WeatherStateService : IWeatherStateService
    {
        private const string ApiKeyUrlParameter = "{API key}";
        private const string ZipUrlParameter = "{zip}";
        private const string ZipCodeArgumentError = "zipCode must consist's of 5 digits";

        private readonly HttpClient _httpClient;
        private readonly string _getWeatherStateByZipCodeUrl;
        private readonly Regex _zipCodeRegex = new Regex(@"\d{5}");

        public WeatherStateService(HttpClient httpClient, IOptions<WeatherStateServiceOptions> options)
        {
            _httpClient = httpClient;
            _getWeatherStateByZipCodeUrl = options
                .Value
                .GetWeatherStateByZipCodeUrl.Replace(ApiKeyUrlParameter, options.Value.ApiKey);
        }

        public async Task<WeatherState> GetAsync(string zipCode)
        {
            if (!_zipCodeRegex.IsMatch(zipCode))
                throw new ArgumentException(ZipCodeArgumentError);

            var tokinezedUrl = _getWeatherStateByZipCodeUrl.Replace(ZipUrlParameter, zipCode);
            var reponse = await _httpClient.GetAsync<OpenWeatherByZipCodeState>(tokinezedUrl);
            return new WeatherState(reponse.main.temp, reponse.name, DateTime.Now);
        }
    }
}

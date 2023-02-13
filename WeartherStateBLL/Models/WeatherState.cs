using System;

namespace WeartherStateBLL.Models
{
    public class WeatherState
    {
        public double Temperature { get; }
        public string City { get; }
        public DateTime RequestTime { get; set; }

        public WeatherState(double temperature, string city, DateTime requestTime)
        {
            Temperature = temperature;
            City = city;
            RequestTime = requestTime;
        }
    }
}

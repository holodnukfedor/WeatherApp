using System.Threading.Tasks;
using WeartherStateBLL.Models;

namespace WeartherStateBLL.Interfaces
{
    public interface IWeatherStateService
    {
        Task<WeatherState> GetAsync(string zip);
    }
}

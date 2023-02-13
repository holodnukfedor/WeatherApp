using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WeartherStateBLL.Interfaces;
using WeartherStateBLL.Utils;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private IWeatherStateService _weatherStateService;

        public WeatherController(IWeatherStateService weatherStateService)
        {
            _weatherStateService = weatherStateService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [Required]
            [RegularExpression(@"\d{5}")]
            string zipCode)
        {
            try
            {
                return Ok(await _weatherStateService.GetAsync(zipCode));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}

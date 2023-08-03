using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWeather.Model;
using SampleWeather.Service;

namespace SampleWeather.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        protected readonly IFileReader<Weather> FilreReader;
        public WeatherController(IFileReader<Weather> FilreReader)
        {
                this.FilreReader = FilreReader;
        }


        [HttpGet("Temperature")]
        public IActionResult GetTemperature([FromQuery] string query)
        {
            var result = FilreReader.Read().FirstOrDefault(x=>x.Name==query);
            if (result == null)
                return NotFound(query);
            else
                return Ok(result);

        }

        [HttpPost("Temperature")]
        public IActionResult Temperature([FromBody] string query)
        {
            var result = FilreReader.Read().FirstOrDefault(x => x.Name == query);
            if (result == null)
                return NotFound(query);
            else
                return Ok(result);

        }
    }
}

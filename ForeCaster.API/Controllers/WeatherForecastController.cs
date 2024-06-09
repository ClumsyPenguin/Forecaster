using ForeCaster.API.Adapters.OpenMeteo;
using ForeCaster.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForeCaster.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController(IMeteoApiClient meteoApiClient) : ControllerBase
{
    private readonly WeatherForecastService _weatherService = new(meteoApiClient);
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetWeatherforecast()
    {
        var response = await _weatherService.GetWeatherForecast(52.52, 13.41);
        return Ok(response);
    }
}
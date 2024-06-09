using ForeCaster.Shared.DTOs;

namespace ForeCaster.Web.Services;

public class WeatherForecastService(IHttpClientFactory httpClientFactory)
{
    public async Task<WeatherForecastDto> GetWeatherForecast()
    {
        using var client = httpClientFactory.CreateClient(Constants.ApiClientName);

        var re = await client.GetAsync("weatherforecast");
        
        var response = await client.GetFromJsonAsync<WeatherForecastDto>("weatherforecast");

        if (response is null)
            throw new Exception("Failed to retrieve weather forecast data.");

        return response;
    }
}
using System.Reflection.Metadata;
using ForeCaster.API.Adapters.OpenMeteo.Models;

namespace ForeCaster.API.Adapters.OpenMeteo;

public class MeteoApiClient : IMeteoApiClient
{
    private readonly HttpClient _httpClient;

    public MeteoApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast");

    }
    public async Task<MeteoResponse[]> GetMeteoForecast(double latitude, double longitude)
    {
        var response = await _httpClient.GetFromJsonAsync<MeteoResponse[]>($"?latitude={latitude}&longitude={longitude}&hourly=temperature_2m");

        if (response is null)
            throw new Exception("Failed to get response from OpenMeteo API");
        
        return response;
    }
}
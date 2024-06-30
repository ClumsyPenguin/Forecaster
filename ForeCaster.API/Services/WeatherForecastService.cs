using ForeCaster.API.Adapters.OpenMeteo;
using ForeCaster.API.Adapters.OpenMeteo.Models;
using ForeCaster.API.Attributes;

namespace ForeCaster.API.Services;

public class WeatherForecastService(IMeteoApiClient meteoApiClient)
{
    [Cache(5)]
    public async Task<MeteoResponse[]> GetWeatherForecast(double latitude, double longitude)
    {
        //TODO it is not a good idea to depend on the concrete implementation of meteo api response, we should create a domain model and map the response to the domain model
        var meteoResponse = await meteoApiClient.GetMeteoForecast(latitude, longitude);
        
        return meteoResponse;
    }
}
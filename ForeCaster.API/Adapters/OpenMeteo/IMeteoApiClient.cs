using ForeCaster.API.Adapters.OpenMeteo.Models;

namespace ForeCaster.API.Adapters.OpenMeteo;

public interface IMeteoApiClient
{
    Task<MeteoResponse[]> GetMeteoForecast(double latitude, double longitude);
}
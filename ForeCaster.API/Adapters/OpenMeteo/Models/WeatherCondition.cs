namespace ForeCaster.API.Adapters.OpenMeteo.Models;

// Weather condition status codes as per WMO
public enum WeatherCondition
{
    // Clear sky
    ClearSky = 0,

    // Mainly clear, partly cloudy, and overcast
    MainlyClear = 1,
    PartlyCloudy = 2,
    Overcast = 3,

    // Fog and depositing rime fog
    Fog = 45,
    DepositingRimeFog = 48,

    // Drizzle: Light, moderate, and dense intensity
    LightDrizzle = 51,
    ModerateDrizzle = 53,
    DenseDrizzle = 55,

    // Freezing Drizzle: Light and dense intensity
    LightFreezingDrizzle = 56,
    DenseFreezingDrizzle = 57,

    // Rain: Slight, moderate and heavy intensity
    SlightRain = 61,
    ModerateRain = 63,
    HeavyRain = 65,

    // Freezing Rain: Light and heavy intensity
    LightFreezingRain = 66,
    HeavyFreezingRain = 67,

    // Snow fall: Slight, moderate, and heavy intensity
    SlightSnowFall = 71,
    ModerateSnowFall = 73,
    HeavySnowFall = 75,

    // Snow grains
    SnowGrains = 77,

    // Rain showers: Slight, moderate, and violent
    SlightRainShowers = 80,
    ModerateRainShowers = 81,
    ViolentRainShowers = 82,

    // Snow showers slight and heavy
    SlightSnowShowers = 85,
    HeavySnowShowers = 86,

    // Thunderstorm: Slight or moderate
    SlightThunderstorm = 95,

    // Thunderstorm with slight and heavy hail
    ThunderstormWithSlightHail = 96,
    ThunderstormWithHeavyHail = 99
}


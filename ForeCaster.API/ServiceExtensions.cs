using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using Marvin.Cache.Headers;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Serialization.SystemTextJson;

namespace ForeCaster.API;

public static class ServiceExtensions
{
    public static void AddCache(this IServiceCollection services, IConfiguration configuration, List<JsonConverter> jsonConverters)
    {
        services.AddMemoryCache();
        
        IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(configuration["RedisCache:ConnectionString"] ?? throw new ConfigurationErrorsException("Redis connection is missing in the configuration"));

        services.AddSingleton<IConnectionMultiplexer>(_ => multiplexer);

        var jsonSerializerOptions = CreateSerializerOptions(jsonConverters);

        services.AddFusionCache()
            .WithDefaultEntryOptions(new FusionCacheEntryOptions
            {
                IsFailSafeEnabled = true,
                FailSafeMaxDuration = TimeSpan.FromMinutes(5),
                FailSafeThrottleDuration = TimeSpan.FromMinutes(1),
                JitterMaxDuration = TimeSpan.FromSeconds(2)
            })
            .WithSerializer(new FusionCacheSystemTextJsonSerializer(jsonSerializerOptions))
            .WithDistributedCache(new RedisCache(new RedisCacheOptions { ConnectionMultiplexerFactory = () => Task.FromResult(multiplexer) }));
    }
    
    public static void AddHttpCacheHeaders(this IServiceCollection services)
    {
        services.AddResponseCaching();
        services.AddHttpCacheHeaders(
            expirationOpt =>
            {
                expirationOpt.MaxAge = 65;
                expirationOpt.CacheLocation = CacheLocation.Private;
            },
            validationOpt =>
            {
                validationOpt.MustRevalidate = true;
            }
        );
    }
    
    
    private static JsonSerializerOptions CreateSerializerOptions(List<JsonConverter> jsonConverters)
    {
        var jsonSerializerOptions = new JsonSerializerOptions();

        foreach (var jsonConverter in jsonConverters)
        {
            jsonSerializerOptions.Converters.Add(jsonConverter);
        }

        return jsonSerializerOptions;
    }
}

using ForeCaster.API.Helpers;
using Metalama.Extensions.DependencyInjection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code.SyntaxBuilders;
using ZiggyCreatures.Caching.Fusion;
using static Metalama.Framework.Aspects.meta;

namespace ForeCaster.API.Attributes;

/// <inheritdoc />
[AttributeUsage(AttributeTargets.Method)]
public class CacheAttribute : OverrideMethodAspect
{
    private readonly TimeSpan _cacheDurationInMinutes;

    [IntroduceDependency]
    private readonly IFusionCache _fusionCache;
    
    public CacheAttribute(int cacheDurationInMinutes)
    {
        _cacheDurationInMinutes = TimeSpan.FromMinutes(cacheDurationInMinutes);
    }
    
    // public override dynamic? OverrideMethod()
    // {
    //     var cacheKey = CacheKeyBuilder.GetCachingKey().ToValue();
    //
    //     var cachedValue = _fusionCache.TryGet(cacheKey);
    //     if (cachedValue is not null)
    //         return cachedValue;
    //     
    //     var returned = Proceed();
    //     
    //     _fusionCache.Set(cacheKey, returned, options: new FusionCacheEntryOptions(_cacheDurationInMinutes));
    //     
    //     return returned;
    // }
    
    public override dynamic? OverrideMethod()
    {
        var cacheKey = CacheKeyBuilder.GetCachingKey().ToValue();
        
        return _fusionCache.GetOrSet(cacheKey, Proceed(), options: new FusionCacheEntryOptions(_cacheDurationInMinutes));
    }
}
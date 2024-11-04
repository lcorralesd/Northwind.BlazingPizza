using System.Text.Json;

namespace Northwind.BlazingPizza.GetSpecials.Core.Cache;
internal class GetSpecialsCache(IDistributedCache cache,
    ILogger<GetSpecialsCache> logger) : IGetSpecialsCache
{
    const string CacheKey = "pizzaSpecials";

    public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync()
    {
        IEnumerable<PizzaSpecialDto> specials = null;
        try
        {
            string specialsJson = await cache.GetStringAsync(CacheKey);
            if (!string.IsNullOrEmpty(specialsJson))
            {
                specials = JsonSerializer.Deserialize<IEnumerable<PizzaSpecialDto>>(specialsJson);
                logger.LogInformation("Specials retrieved from cache");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting specials from cache");
        }
        return specials;
    }

    public Task SetSpecialsAsync(IEnumerable<PizzaSpecialDto> pizzaSpecials)
    {
        try
        {
            string specialsJson = JsonSerializer.Serialize(pizzaSpecials);
            cache.SetStringAsync(CacheKey, specialsJson);
            logger.LogInformation("Specials saved to cache");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error saving specials to cache");
        }
        return Task.CompletedTask;
    }
}

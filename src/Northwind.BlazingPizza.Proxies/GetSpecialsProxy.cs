using Microsoft.Extensions.Logging;
using Northwind.BlazingPizza.GetSpecials.Entities.Dtos;
using Northwind.BlazingPizza.GetSpecials.Entities.ValueObjects;
using System.Net.Http.Json;

namespace Northwind.BlazingPizza.Proxies;
public class GetSpecialsProxy(HttpClient httpClient, ILogger<GetSpecialsProxy> logger)
{
    public async Task<IEnumerable<PizzaSpecialDto>> GetSpecialsAsync()
    {
        IEnumerable<PizzaSpecialDto> specials = null;

        try
        {
            var response = await httpClient.GetAsync(Endpoints.GetSpecials);
            var responseContent = await response.Content.ReadAsStringAsync();

            logger.LogInformation("HTTP Status Code {code}", response.StatusCode);
            logger.LogInformation("HTTP Response Content {content}", responseContent);

            if (response.IsSuccessStatusCode)
            {
                specials = await response.Content.ReadFromJsonAsync<IEnumerable<PizzaSpecialDto>>();
            }

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting specials");
        }

        return specials ?? Enumerable.Empty<PizzaSpecialDto>();

    }
}

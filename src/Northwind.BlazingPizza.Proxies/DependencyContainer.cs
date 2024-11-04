using Microsoft.Extensions.DependencyInjection;

namespace Northwind.BlazingPizza.Proxies;
public static class DependencyContainer
{
    public static IServiceCollection AddProxies(this IServiceCollection services, Action<HttpClient> configureGetSpecialsProxy)
    {
        services.AddHttpClient<GetSpecialsProxy>(configureGetSpecialsProxy);
        return services;
    }
}

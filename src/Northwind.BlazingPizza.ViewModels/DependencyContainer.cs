using Microsoft.Extensions.DependencyInjection;
using Northwind.BlazingPizza.ViewModels.GetSpecials;

namespace Northwind.BlazingPizza.ViewModels;
public static class DependencyContainer
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddScoped<GetSpecialsViewModel>();
        return services;
    }
}

namespace Northwind.BlazingPizza.GetSpecials.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddGetSpecialsServices(this IServiceCollection services, Action<GetSpecialsOptions> configureGetSpecialsOptions, Action<GetSpecialsDBOptions> configureGetSpecialsDBOptions)
    {
        services.AddGetSpecialsCoreService(configureGetSpecialsOptions);
        services.AddGetSpecialsRepositories(configureGetSpecialsDBOptions);

        return services;
    }
}

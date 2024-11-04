namespace Northwind.BlazingPizza.GetSpecials.Repositories;
public static class DependencyContainer
{
    public static IServiceCollection AddGetSpecialsRepositories(this IServiceCollection services, Action<GetSpecialsDBOptions> configureGetSpecialsDBOptions)
    {
        services.AddDbContext<GetSpecialsContext>();

        services.AddScoped<IGetSpecialsRepository, GetSpecialsRepository>();

        services.Configure<GetSpecialsDBOptions>(configureGetSpecialsDBOptions);

        return services;
    }

    public static IHost InitializeDB(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<GetSpecialsContext>();
        context.Database.EnsureCreated();
        return app;
    }
}

using Northwind.BlazingPizza.GetSpecials.Core.Cache;

namespace Northwind.BlazingPizza.GetSpecials.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetSpecialsCoreService(this IServiceCollection services, Action<GetSpecialsOptions> configureGetSpecialsOptions)
        {
            services.AddScoped<IGetSpecialsInputPort, GetSpecialsInteractor>();
            services.AddScoped<IGetSpecialsOutputPort, GetSpecialsPresenter>();
            services.AddScoped<IGetSpecialsController, GetSpecialsController>();

            services.AddSingleton<IGetSpecialsCache, GetSpecialsCache>();

            services.Configure(configureGetSpecialsOptions);


            return services;
        }
    }
}


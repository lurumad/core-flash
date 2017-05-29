using Core.Flash;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFlashes(this IServiceCollection services)
        {
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddScoped<IFlasher, Flasher>();

            return services;
        }
    }
}

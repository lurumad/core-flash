using Core.Flash;
using Core.Flash.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFlashes(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.TryAddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddTransient<IFlasher, Flasher>();

            return services;
        }
    }
}

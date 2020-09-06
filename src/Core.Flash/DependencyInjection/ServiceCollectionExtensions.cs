using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Core.Flash;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFlashes<T>(this IServiceCollection services) where T: class, IMessageRenderer
        {
            services.AddHttpContextAccessor();
            services.TryAddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.TryAddSingleton<IMessageRenderer, T>();
            services.AddTransient<IFlasher, Flasher>();

            return services;
        }
    }
}

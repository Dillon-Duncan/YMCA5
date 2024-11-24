using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using YmcaApiClient.Models;

namespace YmcaApiClient.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddYmcaApiClientService(this IServiceCollection services,
            Action<ApiClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new YmcaApiClientService(options);
            });
        }
    }
}
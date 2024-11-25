using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using YMCA3.YmcaApiClient.Models;

namespace YMCA3.YmcaApiClient.IoC
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
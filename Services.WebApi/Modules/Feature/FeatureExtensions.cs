using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Services.WebApi.Modules
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()));
            services.AddMvc();

            return services;
        }
    }
}

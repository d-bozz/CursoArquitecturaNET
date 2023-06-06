using Application.Interface;
using Application.Main;
using Cross.Common;
using Cross.Logging;
using Domain.Core;
using Domain.Interface;
using Dominio.Core;
using Dominio.Interface;
using Infraestructura.Data;
using Infraestructura.Interface;
using Infraestructura.Repository;
using Infraestructure.Interface;

namespace Services.WebApi.Modules
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

using Application.Data;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infraestructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApiSerilogBdContext, ApiSerilogBdContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString(name: "Default")));

            return services;
        }
    }
}

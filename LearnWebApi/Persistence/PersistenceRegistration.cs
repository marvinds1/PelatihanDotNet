using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Models;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnection = configuration.GetConnectionString("Database");
            string redisConnection = configuration.GetConnectionString("Redis");

            services.AddDbContext<TableContext>(opt => opt.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection)));
            services.AddDbContext<ApplicationDBContext>(opt => opt.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection)));

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = redisConnection;
            });
            services.AddScoped<ITableSpecificationRepository, TableSpecificationRepository>();
            

            return services;
        }
    }

}

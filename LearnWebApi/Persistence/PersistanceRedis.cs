using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistanceRedis
    {
        public static IServiceCollection AddPersistanceRedis(this IServiceCollection services, IConfiguration configuration)
        {
            string redisConnection = configuration.GetConnectionString("Redis");

            var redis = ConnectionMultiplexer.Connect(redisConnection);
            services.AddSingleton(redis);

            services.AddScoped<ICacheService, RedisCacheService>();
            

            return services;
        }
    }
}

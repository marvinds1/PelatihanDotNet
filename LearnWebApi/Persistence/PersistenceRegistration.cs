using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Persistence.DatabaseContext;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        const string dbConnection = "Server=localhost;Database=DB_Dotnet;User=root;Password=admin123;SslMode=None;";

        services.AddDbContext<TableContext>(opt => opt.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection)));
        services.AddScoped<ITableSpecificationRepository, TableSpecificationRepository>();

        return services;
    }
}
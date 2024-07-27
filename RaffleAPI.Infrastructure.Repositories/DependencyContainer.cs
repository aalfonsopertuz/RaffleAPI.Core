using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RaffleAPI.Domain.Repositories.Repositories;
using RaffleAPI.Infrastructure.Data.Context;
using RaffleAPI.Infrastructure.Repositories.Repositories;

namespace RaffleAPI.Infrastructure.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Obtiene la cadena de conexión desde la configuración
            string serverName = Environment.GetEnvironmentVariable("SQL_SERVER_NAME") ?? "";
            string dataBaseName = Environment.GetEnvironmentVariable("SQL_DATABASE_NAME") ?? "";

            string connectionString = $"Server={serverName};Database={dataBaseName};Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

            // Configura el contexto de base de datos ORM
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<DbContext, ApplicationDbContext>();


            // Configura el contexto de base de datos para ADO.NET
            services.AddTransient<SqlConnection>(_ => new SqlConnection(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRaffleRepository, RaffleRepository>();
            return services;
        }
    }
}

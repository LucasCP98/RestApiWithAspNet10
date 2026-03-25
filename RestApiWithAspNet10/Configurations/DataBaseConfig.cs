using Microsoft.EntityFrameworkCore;
using RestApiWithAspNet10.Controllers.Model.Context;

namespace RestApiWithAspNet10.Configurations
{
    public static class DataBaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string 'MSSQLServerSQLConnectionString' not found.");
            }

            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
            return services;

        }
    }
}
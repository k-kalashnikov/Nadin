using Microsoft.Extensions.Configuration;

namespace Nadin.Persistence.Extensions
{
    public static class ContextExtension
    {
        public static string BuildConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("PostgresConnection:connectionString") + $"Database={configuration.GetConnectionString("PostgresConnection:Database")};";
    }
}

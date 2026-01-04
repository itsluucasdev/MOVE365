using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

namespace M365.Infrastructure.Extensions;

public static class HealthChecksExtensions
{
    public static void AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddMongoDb(_ =>
                {
                    var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
                    return client.GetDatabase("Move365");
                },
                name: "mongodb",
                timeout: TimeSpan.FromSeconds(5)
            );
    }
}
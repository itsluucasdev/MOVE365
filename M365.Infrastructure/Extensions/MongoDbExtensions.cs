using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MongoDB.Driver;

namespace M365.Infrastructure.Extensions;

public static class MongoDbExtensions
{
    public static void ConfigureMongoDb(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(cfg["MongoDbOptions:DatabaseName"]!);
        });
    }
}
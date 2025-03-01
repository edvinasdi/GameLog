using GameLog.Infrastructure.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace GameLog.Infrastructure.Startup;

public static class MongoStartup
{
    public static void RegisterDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var mongoDbSection = configuration.GetSection("MongoDb");

        var mongoClientSettings = MongoClientSettings.FromConnectionString(mongoDbSection["ConnectionString"]);
        var mongoClient = new MongoClient(mongoClientSettings);

        services
            .AddSingleton<IMongoClient>(mongoClient)
            .AddSingleton<IMongoDatabase>(sp =>
            {
                var gameLogDatabaseName = mongoDbSection["GameLogDatabase"];
                return sp
                    .GetRequiredService<MongoClient>()
                    .GetDatabase(gameLogDatabaseName);
            });
        
        RegisterCollections(services);
    }

    private static void RegisterCollections(this IServiceCollection services)
    {
        services
            .AddSingleton<IMongoCollection<GameLogEntity>>(sp =>
                sp.GetRequiredService<IMongoDatabase>().GetCollection<GameLogEntity>("gameLogs"));
    }
}
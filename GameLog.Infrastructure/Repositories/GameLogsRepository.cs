using GameLog.Infrastructure.Contracts;
using MongoDB.Driver;

namespace GameLog.Infrastructure.Repositories;

public interface IGameLogsRepository
{
    Task CreateGameLog(GameLogEntity gameLog);
}

public class GameLogsRepository(IMongoCollection<GameLogEntity> collection) : IGameLogsRepository
{
    public async Task CreateGameLog(GameLogEntity gameLog)
    {
        await collection.InsertOneAsync(gameLog);
    }
}
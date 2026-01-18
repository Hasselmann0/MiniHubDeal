using MiniHub.App.Interfaces;
using MiniHub.Domain.Entities;
using MiniHub.Infra.Context;
using MongoDB.Driver;

namespace MiniHub.Infra.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly MiniHubMongoDbContext _collection;

        public LogRepository(MiniHubMongoDbContext collection)
        {
            _collection = collection;
        }
        public async Task AdicionarLogAsync(LogModel log)
        {
            await _collection.Logs.InsertOneAsync(log);
        }
    }
}

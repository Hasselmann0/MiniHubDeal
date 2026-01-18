using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniHub.Domain.Entities;
using MongoDB.Driver;

namespace MiniHub.Infra.Context
{
    public class MiniHubMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MiniHubMongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MongoSettings")["ConnectionString"];
            var client = new MongoClient(connectionString);

            var databaseName = MongoUrl.Create(connectionString).DatabaseName ?? "MiniHubLogs";
            _database = client.GetDatabase(databaseName);

            MongoDbPersistence.Configure();
        }

        public IMongoCollection<LogModel> Logs => _database.GetCollection<LogModel>("logs");
    }
}

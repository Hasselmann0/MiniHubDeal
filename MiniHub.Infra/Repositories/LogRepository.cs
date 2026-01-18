using MiniHub.App.Interfaces;
using MiniHub.Domain.Entities;
using MiniHub.Infra.Context;

namespace MiniHub.Infra.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly MiniHubMongoDbContext _context;

        public LogRepository(MiniHubMongoDbContext context)
        {
            _context = context;
        }
        public async Task AdicionarLogAsync(LogModel log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}

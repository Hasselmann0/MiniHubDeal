
using Microsoft.EntityFrameworkCore;
using MiniHub.Domain.Entities;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MiniHub.Infra.Context
{
    public class MiniHubMongoDbContext : DbContext
    {
        public DbSet<LogModel> Logs { get; set; }

        public MiniHubMongoDbContext(DbContextOptions<MiniHubMongoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LogModel>().ToCollection("Logs");

            modelBuilder.Entity<LogModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PayloadJson).HasElementName("payload");
            });
        }
    }
}

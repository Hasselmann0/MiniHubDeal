using Microsoft.EntityFrameworkCore;
using MiniHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MiniHub.Infra.Context
{
    public class MiniHubDbContext : DbContext
    {
        public MiniHubDbContext(DbContextOptions<MiniHubDbContext> options) : base(options)
        {

        }

        public DbSet<ItemModel> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}

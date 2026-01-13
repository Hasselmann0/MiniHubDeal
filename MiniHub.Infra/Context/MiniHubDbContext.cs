using Microsoft.EntityFrameworkCore;
using MiniHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Infra.Context
{
    public class MiniHubDbContext : DbContext
    {
        public MiniHubDbContext(DbContextOptions<MiniHubDbContext> options) : base(options)
        {

        }

        public DbSet<ItemModel> Items { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TagModel> Tags { get; set; }
    }
}

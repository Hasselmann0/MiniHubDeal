using Microsoft.EntityFrameworkCore;
using MiniHub.Domain.Entities;
using MiniHub.Infra.Context;
using MiniHub.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Infra.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly MiniHubDbContext _context;

        public ItemRepository(MiniHubDbContext context)
        {
            _context = context;
        }

        public Task<List<ItemModel>> ObterTodos()
        {
            return _context.Items
                .ToListAsync();
        }

        public async Task<ItemModel?> ObterPorId(Guid id)
        {
            return await _context.Items
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();
        }

        public void AdicionarItem(ItemModel ItemDTO)
        {
            _context.Items.Add(ItemDTO);
            _context.SaveChanges();
        }

        public void AtualizarItem(ItemModel ItemDTO)
        {
            _context.Items.Update(ItemDTO);
            _context.SaveChanges();
        }

        public void DeletarItem(ItemModel id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MiniHub.App.DTOs;
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

        public async Task<IEnumerable<ItemModel>> BuscarAvancadoAsync(FiltroBuscaDto filtro)
        {
 
            var query = _context.Items.AsNoTracking().AsQueryable();

            if (filtro.ApenasAtivos ?? true)
            {
                query = query.Where(p => p.Ativo);
            }
            else if (filtro.ApenasAtivos == false)
            {
                query = query.Where(p => !p.Ativo);
            }

            if (!string.IsNullOrEmpty(filtro.Categoria))
            {
                query = query.Where(p => p.Categoria == filtro.Categoria);
            }

            if (filtro.PrecoMin.HasValue)
            {
                query = query.Where(p => p.Preco >= filtro.PrecoMin.Value);
            }

            if (filtro.PrecoMax.HasValue)
            {
                query = query.Where(p => p.Preco <= filtro.PrecoMax.Value);
            }

            if (!string.IsNullOrWhiteSpace(filtro.TermoBusca))
            {
                var termo = filtro.TermoBusca.ToLower();
                query = query.Where(p =>
                    p.Nome.ToLower().Contains(termo) ||
                    p.Descricao.ToLower().Contains(termo) ||
                    p.Tag.ToLower().Contains(termo));
            }

            query = query.OrderByDescending(p => p.CriadoEm);


            query = query
                .Skip((filtro.Pagina - 1) * filtro.ItensPorPagina)
                .Take(filtro.ItensPorPagina);

            return await query.ToListAsync();
        }
    }
}

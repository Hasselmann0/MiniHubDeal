using MiniHub.App.DTOs;
using MiniHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Infra.Interfaces
{
    public interface IItemRepository
    {
        Task<ItemModel?> ObterPorId (Guid id);
        Task<List<ItemModel>> ObterTodos ();
        void AdicionarItem(ItemModel ItemDTO);
        void AtualizarItem(ItemModel ItemDTO);
        void DeletarItem(ItemModel id);
        Task<IEnumerable<ItemModel>> BuscarAvancadoAsync(FiltroBuscaDto filtro);
    }
}

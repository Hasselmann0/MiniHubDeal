using MiniHub.App.DTOs;

namespace MiniHub.App.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> ObterTodosAsync();
        Task<ItemDTO?> ObterPorIdAsync(Guid id);
        Task<ItemDTO> AdicionarAsync(ItemDTO itemDto);
        Task<ItemDTO?> AtualizarAsync(Guid id, ItemDTO itemDto);
        Task<bool> DeletarAsync(Guid id);
    }
}

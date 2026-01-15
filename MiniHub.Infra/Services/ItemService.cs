using MiniHub.App.DTOs;
using MiniHub.App.Interfaces;
using MiniHub.Domain.Entities;
using MiniHub.Infra.Interfaces;

namespace MiniHub.App.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemDTO>> ObterTodosAsync()
        {
            var items = await _itemRepository.ObterTodos();
            return items.Select(MapToDTO);
        }

        public async Task<ItemDTO?> ObterPorIdAsync(Guid id)
        {
            var item = await _itemRepository.ObterPorId(id);
            return item != null ? MapToDTO(item) : null;
        }

        public async Task<ItemDTO> AdicionarAsync(ItemDTO itemDto)
        {
            var item = new ItemModel
            {
                Nome = itemDto.Nome,
                Descricao = itemDto.Descricao,
                Categoria = itemDto.Categoria,
                Preco = itemDto.Preco,
                Tag = itemDto.Tag,
                Ativo = true,
                CriadoEm = DateTime.Now
            };

            _itemRepository.AdicionarItem(item);
            return MapToDTO(item);
        }

        public async Task<ItemDTO?> AtualizarAsync(Guid id, ItemDTO itemDto)
        {
            var itemExistente = await _itemRepository.ObterPorId(id);
            
            if (itemExistente == null)
                return null;

            itemExistente.Nome = itemDto.Nome;
            itemExistente.Descricao = itemDto.Descricao;
            itemExistente.Categoria = itemDto.Categoria;
            itemExistente.Preco = itemDto.Preco;
            itemExistente.Tag = itemDto.Tag;

            _itemRepository.AtualizarItem(itemExistente);
            return MapToDTO(itemExistente);
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var item = await _itemRepository.ObterPorId(id);
            
            if (item == null)
                return false;

            _itemRepository.DeletarItem(item);
            return true;
        }

        // Método privado para mapeamento de ItemModel para ItemDTO
        private static ItemDTO MapToDTO(ItemModel item)
        {
            return new ItemDTO(
                item.Id,
                item.Nome,
                item.Descricao,
                item.Categoria,
                item.Preco,
                item.Tag
            );
        }
    }
}

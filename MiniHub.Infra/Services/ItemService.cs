using MiniHub.App.DTOs;
using MiniHub.App.Interfaces;
using MiniHub.Domain.Entities;
using MiniHub.Infra.Interfaces;
using MiniHub.Infra.Mappers;
using System.Text;

namespace MiniHub.Infra.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ILogService _logService;

        public ItemService(IItemRepository itemRepository, ILogService  logService)
        {
            _itemRepository = itemRepository;
            _logService = logService;
        }

        public async Task<IEnumerable<ItemDTO>> ObterTodosAsync()
        {
            var items = await _itemRepository.ObterTodos();
            return items.Select(ItemDTOMapper.MapeaItemDto);
        }

        public async Task<ItemDTO?> ObterPorIdAsync(Guid id)
        {
            var item = await _itemRepository.ObterPorId(id);
            return item != null ? ItemDTOMapper.MapeaItemDto(item) : null;
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

            await _logService.RegistrarLogAsync(new LogDTO
            {
                Acao = "CriarProduto",
                Payload = new
                {
                    IdGerado = item.Id,
                    Nome = item.Nome,
                    Data = DateTime.Now
                }
            });

            _itemRepository.AdicionarItem(item);
            return ItemDTOMapper.MapeaItemDto(item);
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
            return ItemDTOMapper.MapeaItemDto(itemExistente);
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var item = await _itemRepository.ObterPorId(id);

            if (item == null)
                return false;

            _itemRepository.DeletarItem(item);
            return true;
        }

        public async Task<byte[]> ExportarCsvAsync()
        {
            var itens = await _itemRepository.ObterTodos();

            var csvBuilder = new StringBuilder();

            csvBuilder.AppendLine("Nome,Descricao,Categoria,Tag,Preco");

            foreach (var item in itens)
            {
                csvBuilder.AppendLine($"{item.Nome},{item.Descricao},{item.Categoria},{item.Tag},{item.Preco}");
            }

            return Encoding.UTF8.GetBytes(csvBuilder.ToString());
        }

        public async Task<IEnumerable<ItemModel>> ObterCatalogo(FiltroBuscaDto filtro)
        {
            return await _itemRepository.BuscarAvancadoAsync(filtro);
        }
    }
}

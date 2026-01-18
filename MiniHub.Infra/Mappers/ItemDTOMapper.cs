using MiniHub.App.DTOs;
using MiniHub.Domain.Entities;

namespace MiniHub.Infra.Mappers
{
    public static class ItemDTOMapper
    {
        public static ItemDTO MapeaItemDto (ItemModel item)
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

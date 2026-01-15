using Microsoft.AspNetCore.Mvc;
using MiniHub.App.DTOs;
using MiniHub.App.Interfaces;

namespace MiniHub.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Items()
        {
            var items = await _itemService.ObterTodosAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ItemPorId(Guid id)
        {
            var item = await _itemService.ObterPorIdAsync(id);
            
            if (item == null)
                return NotFound(new { message = $"Item com ID {id} não encontrado." });
            
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItem([FromBody] ItemDTO itemDto)
        {
            if (itemDto == null)
                return BadRequest(new { message = "Dados inválidos." });

            var item = await _itemService.AdicionarAsync(itemDto);
            return CreatedAtAction(nameof(ItemPorId), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarItem(Guid id, [FromBody] ItemDTO itemDto)
        {
            if (itemDto == null)
                return BadRequest(new { message = "Dados inválidos." });

            var item = await _itemService.AtualizarAsync(id, itemDto);
            
            if (item == null)
                return NotFound(new { message = $"Item com ID {id} não encontrado." });

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarItem(Guid id)
        {
            var deletado = await _itemService.DeletarAsync(id);
            
            if (!deletado)
                return NotFound(new { message = $"Item com ID {id} não encontrado." });

            return NoContent();
        }
    }
}

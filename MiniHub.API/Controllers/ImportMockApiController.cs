using Microsoft.AspNetCore.Mvc;
using MiniHub.Infra.Services;

namespace MiniHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportMockApiController : ControllerBase
    {
        private readonly ImportMockAPIService _importService;
        public ImportMockApiController(ImportMockAPIService importService)
        {
            _importService = importService;
        }

        [HttpPost]
        public async Task<IActionResult> ImportarDados()
        {
            await _importService.ExecutarImportacaoAsync();
            return Ok("Importação concluída com sucesso.");
        }

    }
}

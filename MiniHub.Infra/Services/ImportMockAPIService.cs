using Microsoft.EntityFrameworkCore;
using MiniHub.App.DTOs;
using MiniHub.Domain.Entities;
using MiniHub.Infra.Context;
using System.Net.Http.Json;

namespace MiniHub.App.Services
{
    public class ImportMockAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly MiniHubDbContext _context;

        // Injeção de dependência
        public ImportMockAPIService(IHttpClientFactory httpClientFactory, MiniHubDbContext context)
        {
            _httpClient = httpClientFactory.CreateClient("ApiExterna"); // Configurado no Program.cs
            _context = context;
        }

        public async Task ExecutarImportacaoAsync()
        {
            // 1. Buscar dados (GET)
            var response = await _httpClient.GetAsync("https://6967c03cbbe157c088b2ebbc.mockapi.io/apiext/v1/Items");
            response.EnsureSuccessStatusCode(); // Lança erro se não for 200 OK

            // 2. Deserializar para o DTO
            var dadosExternos = await response.Content.ReadFromJsonAsync<List<ImportDTO>>();

            if (dadosExternos == null || !dadosExternos.Any()) return;

            // 3. Transformação (Map) -> De DTO para Entidade
            var novosProdutos = new List<ItemModel>();

            foreach (var item in dadosExternos)
            {
                // Validação simples para não duplicar (opcional)

                    novosProdutos.Add(new ItemModel
                    {
                        Id = Guid.NewGuid(),
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        Categoria = item.Categoria,
                        Tag = item.Tag,
                        Preco = item.Preco,
                        Ativo = true,
                        CriadoEm = DateTime.Now
                    });     
            }

            // 4. Persistência em Lote (Bulk Insert)
            if (novosProdutos.Any())
            {
                await _context.Items.AddRangeAsync(novosProdutos);
                await _context.SaveChangesAsync();
            }
        }
    }
}

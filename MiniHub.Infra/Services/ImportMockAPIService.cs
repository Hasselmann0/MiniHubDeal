using Microsoft.EntityFrameworkCore;
using MiniHub.App.DTOs;
using MiniHub.Domain.Entities;
using MiniHub.Infra.Context;
using System.Net.Http.Json;

namespace MiniHub.Infra.Services
{
    public class ImportMockAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly MiniHubDbContext _context;

        public ImportMockAPIService(IHttpClientFactory httpClientFactory, MiniHubDbContext context)
        {
            _httpClient = httpClientFactory.CreateClient("ApiExterna"); // Configurado no Program.cs
            _context = context;
        }

        public async Task ExecutarImportacaoAsync()
        {
            var response = await _httpClient.GetAsync("https://6967c03cbbe157c088b2ebbc.mockapi.io/apiext/v1/Items");
            response.EnsureSuccessStatusCode();

            var dadosExternos = await response.Content.ReadFromJsonAsync<List<ImportDTO>>();

            if (dadosExternos == null || !dadosExternos.Any()) return;

            var novosProdutos = new List<ItemModel>();

            foreach (var item in dadosExternos)
            {
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

            if (novosProdutos.Any())
            {
                await _context.Items.AddRangeAsync(novosProdutos);
                await _context.SaveChangesAsync();
            }
        }
    }
}

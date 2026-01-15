using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MiniHub.App.DTOs
{
    public record ImportDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Nome { get; set; }

        [JsonPropertyName("Description")]
        public string Descricao { get; set; }

        [JsonPropertyName("Category")]
        public string Categoria { get; set; }

        [JsonPropertyName("Price")]
        public decimal Preco { get; set; }

        [JsonPropertyName("Tags")]
        public string Tag { get; set; }
    }
}

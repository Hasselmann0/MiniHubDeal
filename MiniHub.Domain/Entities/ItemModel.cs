using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniHub.Domain.Entities
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Tag { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime CriadoEm { get; set; } = DateTime.Now;

    }
}

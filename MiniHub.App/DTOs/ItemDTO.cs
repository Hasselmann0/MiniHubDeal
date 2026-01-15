using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.App.DTOs
{
    public record ItemDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Tag { get; set; }

        public ItemDTO(Guid id, string nome, string descricao, string categoria, decimal preco, string tag)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
            Tag = tag;
        }
    }
}

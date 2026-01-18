using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.App.DTOs
{
    public class FiltroBuscaDto
    {
        public string? TermoBusca { get; set; }
        public string? Categoria { get; set; }
        public decimal? PrecoMin { get; set; }
        public decimal? PrecoMax { get; set; }
        public bool? ApenasAtivos { get; set; }
        public int Pagina { get; set; } = 1;
        public int ItensPorPagina { get; set; } = 10;
    }
}

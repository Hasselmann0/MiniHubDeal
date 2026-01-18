using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.App.DTOs
{
    public record LogDTO
    {
        public string Acao { get; set; }
        public object Payload { get; set; }
    }
}

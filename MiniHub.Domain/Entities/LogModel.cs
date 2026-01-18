using System.Text.Json;

namespace MiniHub.Domain.Entities
{
    public class LogModel
    {
        public LogModel(string acao, object payload)
        {
            Id = Guid.NewGuid();
            Acao = acao;
            CriadoEm = DateTime.UtcNow;
            Payload = payload;
        }

        protected LogModel() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Acao { get; set; }
        public object Payload { get; set; }

        //public Guid? UserId { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}

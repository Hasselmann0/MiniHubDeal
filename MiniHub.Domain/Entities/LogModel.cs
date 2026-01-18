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
            SetPayload(payload);
        }

        protected LogModel() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Acao { get; set; }
        public string PayloadJson { get; set; }
        //public Guid? UserId { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public void SetPayload(object payload)
        {
            if (payload != null)
            {
                PayloadJson = JsonSerializer.Serialize(payload);
            }
        }
    }
}

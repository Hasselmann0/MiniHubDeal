using MiniHub.App.DTOs;

namespace MiniHub.App.Interfaces
{
    public interface ILogService
    {
        Task RegistrarLogAsync(LogDTO dto);
    }
}

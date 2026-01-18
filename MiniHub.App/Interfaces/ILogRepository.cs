using MiniHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.App.Interfaces
{
    public interface ILogRepository
    {
        Task AdicionarLogAsync(LogModel log);
    }
}

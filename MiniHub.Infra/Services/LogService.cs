using MiniHub.App.DTOs;
using MiniHub.App.Interfaces;
using MiniHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Infra.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task RegistrarLogAsync(LogDTO dto)
        {
            var log = new LogModel(dto.Acao, dto.Payload);

            await _logRepository.AdicionarLogAsync(log);
        }
    }
}
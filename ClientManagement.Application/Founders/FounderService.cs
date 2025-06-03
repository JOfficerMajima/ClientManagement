using AutoMapper;
using ClientManagement.Application.Exceptions;
using ClientManagement.Application.Founders.Dtos;
using ClientManagement.Domain.Entities;
using ClientManagement.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ClientManagement.Application.Founders
{
    public class FounderService : IFounderService
    {
        private readonly IFounderRepository _founderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FounderService> _logger;

        public FounderService(
            IFounderRepository founderRepository,
            IMapper mapper,
            ILogger<FounderService> logger)
        {
            _founderRepository = founderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(Founder founder)
        {
            _logger.LogInformation($"Добавление учередителя. INN: {founder.INN}, ID: {founder.Id}");

            var founderCheck = await _founderRepository.GetByINNAsync(founder.INN);

            if (founderCheck != null)
            {

                throw new UserFriendlyException($"Учередитель с INN: {founder.INN} уже существует", "CLIENT_EXISTS")
                    .WithData("ID", founder.Id);
            }

            await _founderRepository.AddAsync(founder);
            _logger.LogInformation($"Учередитель с INN: {founder.INN} успешно добавлен");
        }

        public async Task<IEnumerable<FounderDto>> GetAllAsync()
        {
            _logger.LogDebug("Запрос на получение всех учередителей");

            var founder = await _founderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FounderDto>>(founder);
        }

        public async Task<Founder> GetByIdAsync(int id)
        {
            _logger.LogDebug($"Получение учередителя с ID: {id}");

            var founder = await _founderRepository.GetByIdAsync(id);
            if (founder == null)
            {
                throw new UserFriendlyException($"Учередитель с ID {id} не найден", "FOUNDER_NOT_FOUND")
                    .WithData("FounderId", id);
            }
            return founder;
        }

        public async Task<Founder?> GetByINNAsync(int inn)
        {
            _logger.LogDebug($"Получение учередителя с ИНН: {inn}");

            var founder = await _founderRepository.GetByINNAsync(inn);
            if (founder == null)
            {
                throw new UserFriendlyException($"Учередитель с INN {inn} не найден", "FOUNDER_NOT_FOUND")
                    .WithData("FounderINN", inn);
            }
            return founder;
        }

        public async Task UpdateAsync(Founder founder)
        {
            _logger.LogDebug($"Обновление клиента с ID: {founder.Id}");
            _founderRepository.UpdateAsync(founder);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogDebug($"Удаление учередителя с ID: {id}");
            await _founderRepository.DeleteAsync(id);
        }
    }
}

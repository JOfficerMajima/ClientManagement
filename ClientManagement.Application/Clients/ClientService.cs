using AutoMapper;
using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Application.Exceptions;
using ClientManagement.Application.Interfaces;
using ClientManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ClientManagement.Application.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientService> _logger;

        public ClientService(
            IClientRepository clientRepository,
            IMapper mapper,
            ILogger<ClientService> logger)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(Client client)
        {
            _logger.LogInformation($"Добавление клиента. INN: {client.INN}, ID: {client.Id}");

            var clientCheck = await _clientRepository.GetByINNAsync(client.INN);

            if (clientCheck != null)
            {
                throw new UserFriendlyException($"Клиент с INN: {client.INN} уже существует", "CLIENT_EXISTS")
                    .WithData("ID", client.Id);
            }

            await _clientRepository.AddAsync(client);
            _logger.LogInformation($"Клиент с INN: {client.INN} успешно добавлен");
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            _logger.LogDebug("Запрос на получение всех клиентов");

            var clients = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            _logger.LogDebug($"Получение клиента с ID: {id}");

            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                throw new UserFriendlyException($"Клиент с ID {id} не найден", "CLIENT_NOT_FOUND")
                    .WithData("ClientId", id);
            }
            return client;
        }

        public async Task<Client?> GetByINNAsync(int inn)
        {
            _logger.LogDebug($"Получение клиента с ИНН: {inn}");

            var client = await _clientRepository.GetByINNAsync(inn);
            if (client == null)
            {
                throw new UserFriendlyException($"Клиент с INN {inn} не найден", "CLIENT_NOT_FOUND")
                    .WithData("ClientINN", inn);
            }
            return client;
        }

        public async Task UpdateAsync(Client client)
        {
            _logger.LogDebug($"Обновление клиента с ID: {client.Id}");
            _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogDebug($"Удаление клиента с ID: {id}");
            await _clientRepository.DeleteAsync(id);
        }

        public async Task<ClientWithFoundersDto> GetClientWithFoundersAsync(int id)
        {
            var client = await _clientRepository.GetByIdWithFoundersAsync(id);
            return _mapper.Map<ClientWithFoundersDto>(client);
        }
    }
}

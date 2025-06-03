using AutoMapper;
using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Application.Exceptions;
using ClientManagement.Application.Interfaces;
using ClientManagement.Domain.Entities;
using ClientManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _logger.LogInformation($"Добавление клиента с INN: {client.INN}");

            try
            {
                var clientCheck = await _clientRepository.GetByINNAsync(client.INN);

                if (clientCheck != null)
                {
                    throw new UserFriendlyException($"Клиент с INN: {client.INN} уже существует", "CLIENT_EXISTS")
                        .WithData("ID", client.Id);
                }

                await _clientRepository.AddAsync(client);
                _logger.LogInformation($"Клиент с INN: {client.INN} успешно добавлен");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, $"Ошибка при сохранении клиента с INN: {client.INN}");
                throw new UserFriendlyException("Ошибка сохранения клиента", "DB_SAVE_ERROR", ex);
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            _logger.LogDebug($"Получение клиента {id}");

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
                throw new UserFriendlyException($"Клиент с ID {inn} не найден", "CLIENT_NOT_FOUND")
                    .WithData("ClientId", inn);
            }

            return client;
        }

        public Task UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

using ClientManagement.Application.Interfaces;
using ClientManagement.Domain.Entities;
using ClientManagement.Domain.Enums;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ClientService> _logger;

        public ClientService(
            IClientRepository clientRepository,
            IUnitOfWork unitOfWork,
            ILogger<ClientService> logger) 
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task AddAsync(Client client)
        {
            _logger.LogInformation($"Adding new client with INN: {client.INN}");
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                _logger.LogInformation("Transaction started");

                _clientRepository.AddAsync(client);
                await _unitOfWork.CommitAsync();

                _logger.LogInformation($"Client with ID:{client.Id} added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding client with INN: {client.INN}", );
                await _unitOfWork.RollbackAsync();
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

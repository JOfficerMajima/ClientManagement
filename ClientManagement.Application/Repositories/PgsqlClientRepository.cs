using ClientManagement.Application.Interfaces;
using ClientManagement.Domain;
using ClientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Application.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddClientAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Client>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClientAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}

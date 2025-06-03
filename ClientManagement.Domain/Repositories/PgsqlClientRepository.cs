using ClientManagement.Application.Interfaces;
using ClientManagement.Domain;
using ClientManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientManagement.Application.Repositories
{
    public class PgsqlClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public PgsqlClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> GetByINNAsync(int inn)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.INN == inn);
            return client;
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }
        }

        public async Task<Client> GetByIdWithFoundersAsync(int id)
        {
             return await _context.Clients.
                Include(c => c.FounderClients).
                ThenInclude(fc => fc.Founder).
                FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

using ClientManagement.Application.Interfaces;
using ClientManagement.Domain;
using ClientManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                await _context.Clients.AddAsync(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }
        }

        public IQueryable<Client> GetAll()
        {
            return _context.Clients.AsQueryable();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
        }
    }
}

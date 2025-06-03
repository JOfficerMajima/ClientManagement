using ClientManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientManagement.Domain.Repositories
{
    public class PgsqlFounderRepository : IFounderRepository
    {
        private readonly ApplicationDbContext _context;

        public PgsqlFounderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Founder founder)
        {
            await _context.Founders.AddAsync(founder);
        }

        public async Task<IEnumerable<Founder>> GetAllAsync()
        {
            return await _context.Founders.ToListAsync();
        }

        public async Task<Founder> GetByIdAsync(int id)
        {
            return await _context.Founders.FindAsync(id);
        }

        public async Task<Founder> GetByINNAsync(int inn)
        {
            var founder = await _context.Founders.FirstOrDefaultAsync(c => c.INN == inn);
            return founder;
        }

        public async Task UpdateAsync(Founder founder)
        {
            _context.Founders.Update(founder);
        }

        public async Task DeleteAsync(int id)
        {
            var founder = await _context.Founders.FindAsync(id);
            if (founder != null)
            {
                _context.Founders.Remove(founder);
            }
        }
    }
}

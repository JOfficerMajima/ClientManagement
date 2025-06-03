using ClientManagement.Domain.Entities;

namespace ClientManagement.Domain.Repositories
{
    public interface IFounderRepository
    {
        Task AddAsync(Founder founder);
        Task<IEnumerable<Founder>> GetAllAsync();
        Task<Founder> GetByIdAsync(int id);
        Task<Founder> GetByINNAsync(int inn);
        Task UpdateAsync(Founder founder);
        Task DeleteAsync(int id);
    }
}

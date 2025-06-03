using ClientManagement.Application.Founders.Dtos;
using ClientManagement.Domain.Entities;

namespace ClientManagement.Application.Founders
{
    public interface IFounderService
    {
        Task AddAsync(Founder founder);
        Task<IEnumerable<FounderDto>> GetAllAsync();
        Task<Founder?> GetByIdAsync(int id);
        Task<Founder?> GetByINNAsync(int inn);
        Task UpdateAsync(Founder founder);
        Task DeleteAsync(int id);
    }
}

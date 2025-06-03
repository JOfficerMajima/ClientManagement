using ClientManagement.Domain.Entities;

namespace ClientManagement.Application.Interfaces
{
    public interface IClientRepository
    {
        Task AddAsync (Client client);
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> GetByINNAsync (int inn);
        Task UpdateAsync (Client client);
        Task DeleteAsync (int id);
    }
}

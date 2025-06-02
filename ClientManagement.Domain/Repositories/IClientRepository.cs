using ClientManagement.Domain.Entities;

namespace ClientManagement.Application.Interfaces
{
    public interface IClientRepository
    {
        IQueryable<Client> GetAll();
        Task<Client> GetByIdAsync(int  id);
        Task AddAsync (Client client);
        Task UpdateAsync (Client client);
        Task DeleteAsync (int id);
    }
}

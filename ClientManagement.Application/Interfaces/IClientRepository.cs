using ClientManagement.Domain.Entities;

namespace ClientManagement.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<IQueryable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int  id);
        Task AddClientAsync (Client client);
        Task UpdateClientAsync (Client client);
        Task DeleteClientAsync (int id);
    }
}

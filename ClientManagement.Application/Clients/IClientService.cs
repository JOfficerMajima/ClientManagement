using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Domain.Entities;

namespace ClientManagement.Application.Clients
{
    public interface IClientService
    {
        Task AddAsync(Client client);
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task<ClientWithFoundersDto> GetClientWithFoundersAsync(int id);
        Task<Client?> GetByINNAsync(int inn);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}

using ClientManagement.Application.Clients.Dtos;
using ClientManagement.Application.Common;
using ClientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Application.Clients
{
    public interface IClientService
    {
        Task AddAsync(Client client);
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task<Client?> GetByINNAsync(int inn);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}

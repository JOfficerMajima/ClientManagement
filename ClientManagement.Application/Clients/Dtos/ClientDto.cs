using ClientManagement.Application.Common;
using ClientManagement.Domain.Entities;
using ClientManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Application.Clients.Dtos
{
    public class ClientDto : AuditedEntityDto
    {
        [Required]
        public string INN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ClientType Type { get; set; }

        public ICollection<FounderClient> FounderClients { get; set; }
    }
}

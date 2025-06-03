using ClientManagement.Domain.Common;
using ClientManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Domain.Entities
{
    public class Client : AuditedEntity
    {
        [Required]
        public int INN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ClientType Type { get; set; }

        public ICollection<FounderClient> FounderClients { get; set; } = new List<FounderClient>();
    }
}

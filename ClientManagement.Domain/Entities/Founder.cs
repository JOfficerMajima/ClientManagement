using ClientManagement.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Domain.Entities
{
    public class Founder : AuditedEntity
    {
        [Required]
        public int INN { get; set; }

        [Required]
        public string FullName { get; set; }

        public ICollection<FounderClient> FounderClients { get; set; } = new List<FounderClient>();
    }
}

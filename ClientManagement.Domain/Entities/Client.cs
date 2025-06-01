using ClientManagement.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Domain.Entities
{
    public class Client : Entity
    {
        [Required]
        public string INN { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public ClientType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set;} = DateTime.Now;

        public List<Founder> Founders { get; set; }
    }
}

using ClientManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Domain.Entities
{
    public class Founder : Entity
    {
        [Required]
        public string INN { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public ClientType Type { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}

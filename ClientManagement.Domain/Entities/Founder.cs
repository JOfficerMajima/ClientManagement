using ClientManagement.Domain.Common;
using ClientManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Domain.Entities
{
    public class Founder : AuditedEntity
    {
        [Required]
        public int INN { get; set; }

        [Required]
        public string FullName { get; set; }

        public ICollection<FounderClient> FounderClients { get; set; }
    }
}

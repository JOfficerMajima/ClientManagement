using ClientManagement.Application.Common;
using ClientManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Application.Founders.Dtos
{
    public class FounderDto : AuditedEntityDto
    {
        [Required]
        public int INN { get; set; }

        [Required]
        public string FullName { get; set; }

        public ICollection<FounderClient> FounderClients { get; set; }
    }
}

using ClientManagement.Application.Common;
using ClientManagement.Application.Founders.Dtos;
using ClientManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Application.Clients.Dtos
{
    public class ClientWithFoundersDto : EntityDto
    {
        [Required]
        public int INN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ClientType Type { get; set; }

        public List<ShortFounderDto> Founders { get; set; }
    }
}

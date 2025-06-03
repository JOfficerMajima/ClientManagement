using ClientManagement.Application.Common;
using ClientManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Application.Clients.Dtos
{
    public class UpdateClientDto : EntityDto
    {
        public string INN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ClientType Type { get; set; }
    }
}

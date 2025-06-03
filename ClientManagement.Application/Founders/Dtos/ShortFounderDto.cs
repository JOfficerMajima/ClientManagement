using ClientManagement.Application.Common;
using System.ComponentModel.DataAnnotations;

namespace ClientManagement.Application.Founders.Dtos
{
    public class ShortFounderDto : EntityDto
    {
        [Required]
        public int INN { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}

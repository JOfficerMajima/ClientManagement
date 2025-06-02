using ClientManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagement.Domain.Entities
{
    public class FounderClient 
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int FounderId { get; set; }
        public Founder Founder { get; set; }
    }
}

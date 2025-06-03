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

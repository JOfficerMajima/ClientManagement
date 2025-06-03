namespace ClientManagement.Domain.Common
{
    public abstract class AuditedEntity : Entity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}

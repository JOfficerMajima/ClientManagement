namespace ClientManagement.Application.Common
{
    public abstract class AuditedEntityDto : EntityDto
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

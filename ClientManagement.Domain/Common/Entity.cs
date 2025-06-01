namespace ClientManagement.Domain.Common
{
    public abstract class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } 
    }

    public abstract class Entity : Entity<int>
    {

    }
}

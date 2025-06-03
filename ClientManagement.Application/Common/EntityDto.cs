namespace ClientManagement.Application.Common
{
    public abstract class EntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

    public abstract class EntityDto : EntityDto<int>
    {

    }
}

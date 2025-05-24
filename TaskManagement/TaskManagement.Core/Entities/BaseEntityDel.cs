namespace TaskManagement.Core.Entities
{
    public class BaseEntityDel<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntityDel()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public BaseEntityDel(T id, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
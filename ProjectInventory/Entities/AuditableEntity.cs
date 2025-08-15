namespace ProjectInventory.Entities;

public class AuditableEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid? CreatedBy { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    
    public DateTime DeletedAt { get; set; }
    public Guid DeletedBy { get; set; }
}
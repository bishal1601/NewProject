namespace ProjectInventory.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public Guid UnitId { get; set; }
    public Unit Unit { get; set; } = null!;
    public decimal CostPrice { get; set; } 
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; } = true;
}
namespace ProjectInventory.Entities;

public class StockMovement : AuditableEntity
{
    public DateOnly Date { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
    public decimal Quantity { get; set; }
    public decimal Rate { get; set; }
    public decimal? VatPercentage { get; set; }
    public MovementType MovementType { get; set; }
    public Stock Stock { get; set; }    
    public string? InvoiceNumber { get; set; }
    public Guid TypeId { get; set; }
    
}

public enum Stock
{
    In = 1,
    Out = 2,

}

public enum MovementType
{
    Purchase = 1,
    Sale = 2,
    Adjustment = 3,
    Export = 4,
    PurchaseReturn = 5,
    Transfer = 6,
    Damage = 7,
    Opening = 8,
    SaleReturn = 9,
}
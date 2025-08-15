namespace ProjectInventory.Entities;

public class Purchase : AuditableEntity
{
    public string InvoiceNumber { get; set; }
    public DateOnly TransactionDate { get; set; }
    public Guid StakeholderId { get; set; }
    public virtual StakeHolder Stakeholder { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TaxableAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public string? Description { get; set; }
    public decimal GrandTotal => TotalAmount + TaxAmount - DiscountAmount;
    public Status Status { get; set; } = Status.Completed;
}

public enum Status
{
    Pending = 0,
    Completed = 1,
    Cancelled = 2,
    Returned = 3
}
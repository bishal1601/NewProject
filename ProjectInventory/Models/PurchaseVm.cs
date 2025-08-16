using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectInventory.Entities;

namespace ProjectInventory.Models;

public class PurchaseVm
{
    public string InvoiceNumber { get; set; }
    public DateOnly TransactionDate { get; set; }
    public Guid StakeholderId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TaxableAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public string? Description { get; set; }
    public decimal GrandTotal => TotalAmount + TaxAmount - DiscountAmount;
    public Status Status { get; set; } = Status.Completed;
    
    public List<SelectListItem>? Products { get; set; } = new List<SelectListItem>();

    public List<SelectListItem>? StakeHolders { get; set; } = new List<SelectListItem>();
    public Dictionary<string, string>? ProductUnitMap { get; set; } = new Dictionary<string, string>();
    
    public List<StockMovementVm> StockMovements { get; set; } = new List<StockMovementVm>();
}
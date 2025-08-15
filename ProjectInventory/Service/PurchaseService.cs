using Microsoft.JSInterop.Infrastructure;
using ProjectInventory.Data;
using ProjectInventory.Dto;
using ProjectInventory.Entities;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Service;

public class PurchaseService : IPurchaseService
{
    public readonly ApplicationDbContext _context;

    public PurchaseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Purchase> Create(PurchaseDto dto)
    {
        var purchase = new Purchase()
        {
            Id = Guid.NewGuid(),
            Description = dto.Description,
            StakeholderId = dto.StakeholderId,
            Status = dto.Status,
            InvoiceNumber = dto.InvoiceNumber,
            TransactionDate = dto.TransactionDate,
            TotalAmount = dto.TotalAmount,
            TaxableAmount = dto.TaxableAmount,
            TaxAmount = dto.TaxAmount,
            DiscountAmount = dto.DiscountAmount,

        };
        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();
        return purchase;
    }
}
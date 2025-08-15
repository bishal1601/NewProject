using ProjectInventory.Data;
using ProjectInventory.Dto;
using ProjectInventory.Entities;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Service;

public class StockMovementService : IStockMovementService
{
    private readonly ApplicationDbContext _context;

    public StockMovementService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(List<StockMovemetDto> dto)
    {
        var stockMovements = dto.Select(sm => new StockMovement
        {
            Id = Guid.NewGuid(),
            ProductId = sm.ProductId,
            Quantity = sm.Quantity,
            MovementType = sm.MovementType,
            InvoiceNumber = sm.InvoiceNumber,
            Rate = sm.Rate,
            Date = sm.Date,
            VatPercentage = sm.VatPercentage,
            TypeId = sm.TypeId,
            Stock = sm.Stock,
        }).ToList();
        
        await _context.StockMovements.AddRangeAsync(stockMovements);
        return await _context.SaveChangesAsync() > 0;
    }
}
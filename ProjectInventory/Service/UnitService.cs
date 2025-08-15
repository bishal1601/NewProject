using ProjectInventory.Data;
using ProjectInventory.Dto;
using ProjectInventory.Entities;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Service;

public class UnitService : IUnitService
{
    private readonly ApplicationDbContext _context;

    public UnitService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(UnitDto dto)
    {
        var unit = new Unit
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Symbol = dto.Symbol,
            Description = dto.Description,
        };
        _context.Units.Add(unit);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, UnitDto dto)
    {
        var item = await _context.Units.FindAsync(id);
        if (item == null)
            throw new InvalidOperationException($"Item with the Id: {id} not found");

        item.Name = dto.Name;
        item.Symbol = dto.Symbol;
        item.Description = dto.Description;
        item.IsActive = dto.IsActive;

        _context.Units.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await _context.Units.FindAsync(id);
        if (item == null)
        {
            throw new InvalidOperationException($"Item with the Id: {id} not found...");
        }

        _context.Units.Remove(item);
        await _context.SaveChangesAsync();
    }
}
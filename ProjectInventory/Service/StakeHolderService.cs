using ProjectInventory.Data;
using ProjectInventory.Dto;
using ProjectInventory.Entities;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Service;

public class StakeHolderService:IStakeHolderService
{
    private readonly ApplicationDbContext _context;

    public StakeHolderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StakeHolderDto dto)
    {
        var items = new StakeHolder
        {
            Id = dto.Id,
            Name = dto.Name,
            Address = dto.Address,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Type = dto.Type,
            VatNo = dto.VatNo,
            IsActive = dto.IsActive,
            CreatedAt = DateTime.UtcNow
        };
        _context.StakeHolders.Add(items);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id,StakeHolderDto dto)
    {
        var items = await _context.StakeHolders.FindAsync(id);
        
        if (items == null)
            throw new Exception($"Item with the Id : {id} not available...");
        
        items.Name = dto.Name;
        items.Address = dto.Address;
        items.Email = dto.Email;
        items.PhoneNumber = dto.PhoneNumber;
        items.Type = dto.Type;
        items.VatNo = dto.VatNo;
        items.IsActive = dto.IsActive;
        items.UpdatedAt = DateTime.UtcNow;

        _context.StakeHolders.Update(items);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await _context.StakeHolders.FindAsync(id);
        if (item == null)
            throw new InvalidOperationException($"Item with the Id: {id} not found");
        _context.StakeHolders.Remove(item);
        await _context.SaveChangesAsync();
    }
}
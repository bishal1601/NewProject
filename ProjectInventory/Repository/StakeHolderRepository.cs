using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectInventory.Repository.Interface;
using ProjectInventory.Data;
using ProjectInventory.Entities;
using ProjectInventory.Enum;

namespace ProjectInventory.Repository;

public class StakeHolderRepository : IStakeHolderRepository
{
    private readonly ApplicationDbContext _context;

    public StakeHolderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StakeHolder?>> GetAllAsync()
    {
        var items = await _context.StakeHolders.ToListAsync();
        return items;
    }

    public async Task<StakeHolder?> GetByIdAsync(Guid id)
    {
        var item = await _context.StakeHolders.FindAsync(id);
        return item;
    }

    public async Task<List<SelectListItem>?> GetVendor()
    {
       
            return await _context.StakeHolders
                .Where(c => c.IsActive)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
        
    }
    
}
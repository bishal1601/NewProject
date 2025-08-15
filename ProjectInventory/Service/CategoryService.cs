using Microsoft.EntityFrameworkCore;
using ProjectInventory.Data;
using ProjectInventory.Dto;
using ProjectInventory.Entities;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Service;

public class CategoryService :ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(CategoryDto dto)
    {
        var category = new Category
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            IsActive = dto.IsActive
        };
        _context.Categories.Add(category);
        bool isSaved = await _context.SaveChangesAsync() > 0;
        if (!isSaved)
            throw new InvalidOperationException("Unable to insert into the database...");
        return isSaved;
    }

    public async Task EditAsync(Guid id,CategoryDto dto)
    {
         var items = await _context.Categories.FirstOrDefaultAsync(e => e.Id == id);
         if (items == null)
             throw new InvalidOperationException("Item not found with the id: {id}");
         items.Name = dto.Name;
         items.Description = dto.Description ;
         items.IsActive = dto.IsActive;
         _context.Categories.Update(items);
         await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var items = await _context.Categories.FirstOrDefaultAsync(e => e.Id == id);
        if (items == null)
            throw new InvalidOperationException("Cannot delete an item with the given Id: {id}");
        _context.Categories.Remove(items);
        await _context.SaveChangesAsync();
    }
}
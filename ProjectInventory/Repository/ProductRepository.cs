using Microsoft.EntityFrameworkCore;
using ProjectInventory.Data;
using ProjectInventory.Entities;
using ProjectInventory.Repository.Interface;

namespace ProjectInventory.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Product?>> GetAllAsync()
    {
        var items =await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Unit).ToListAsync();
        return items;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var item = await _context.Products.FindAsync(id);
        return item;
    }

}
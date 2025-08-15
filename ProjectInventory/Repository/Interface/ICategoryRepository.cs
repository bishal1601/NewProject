using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectInventory.Entities;

namespace ProjectInventory.Repository.Interface;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid id);
    Task<List<SelectListItem>> GetAllSelectListAsync();
}
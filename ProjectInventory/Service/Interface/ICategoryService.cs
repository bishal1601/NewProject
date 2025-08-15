using Microsoft.AspNetCore.Mvc;
using ProjectInventory.Dto;

namespace ProjectInventory.Service.Interface;

public interface ICategoryService
{
    Task<bool> CreateAsync(CategoryDto dto);
    Task EditAsync(Guid id,CategoryDto dto);
    Task DeleteAsync(Guid id);
}


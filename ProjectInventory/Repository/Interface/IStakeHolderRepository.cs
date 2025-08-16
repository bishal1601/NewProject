using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectInventory.Entities;

namespace ProjectInventory.Repository.Interface;

public interface IStakeHolderRepository
{
    Task<List<StakeHolder?>> GetAllAsync();

    Task<StakeHolder?> GetByIdAsync(Guid id);
    Task<List<SelectListItem>?> GetVendor();
}
using ProjectInventory.Entities;
using ProjectInventory.Dto;
namespace ProjectInventory.Service.Interface;

public interface IProductService
{
   Task<bool> AddAsync(ProductDto dto);
   Task<bool> UpdateAsync(Guid id,ProductDto dto);
   Task<bool> DeleteAsync(Guid id);
}
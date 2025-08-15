using ProjectInventory.Dto;
namespace ProjectInventory.Service.Interface;
public interface IStakeHolderService
{
    Task AddAsync(StakeHolderDto dto);
    
    Task UpdateAsync(Guid id,StakeHolderDto dto);

    Task DeleteAsync(Guid id);
}
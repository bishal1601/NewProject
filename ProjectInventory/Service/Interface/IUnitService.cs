using ProjectInventory.Dto;

namespace ProjectInventory.Service.Interface;

public interface IUnitService
{
    Task AddAsync(UnitDto dto);

    Task UpdateAsync(Guid id, UnitDto dto);

    Task DeleteAsync(Guid id);
}
using ProjectInventory.Dto;

namespace ProjectInventory.Service.Interface;

public interface IStockMovementService
{
    Task<bool> Create(List<StockMovemetDto> dto);
}
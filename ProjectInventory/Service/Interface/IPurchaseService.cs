using ProjectInventory.Dto;
using ProjectInventory.Entities;

namespace ProjectInventory.Service.Interface;

public interface IPurchaseService
{
    Task<Purchase> Create(PurchaseDto dto);
}
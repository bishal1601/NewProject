using Microsoft.AspNetCore.Mvc;
using ProjectInventory.Dto;
using ProjectInventory.Models;
using ProjectInventory.Repository.Interface;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Controllers;

public class StakeHolderController : Controller
{
    private readonly IStakeHolderRepository _repository;
    private readonly IStakeHolderService _service;

    public StakeHolderController(IStakeHolderRepository repository,IStakeHolderService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
            var items = await _repository.GetAllAsync();
            return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StakeHolderVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        var items = new StakeHolderDto
        {
            Id = Guid.NewGuid(),
            Name = vm.Name,
            Address = vm.Address,
            Email = vm.Email,
            PhoneNumber = vm.PhoneNumber,
            Type = vm.Type,
            VatNo = vm.VatNo,
            IsActive = vm.IsActive
        };
        await _service.AddAsync(items);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        var itemList = new StakeHolderEditVm
        {
            Name = item.Name,
            Address = item.Address,
            Email = item.Email,
            PhoneNumber = item.PhoneNumber,
            Type = item.Type,
            VatNo = item.VatNo,
            IsActive = item.IsActive
        };
        return View(itemList);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, StakeHolderEditVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        var items = new StakeHolderDto
        {
            Name = vm.Name,
            Address = vm.Address,
            Email = vm.Email,
            PhoneNumber = vm.PhoneNumber,
            Type = vm.Type,
            VatNo = vm.VatNo,
            IsActive = vm.IsActive
        };
        await _service.UpdateAsync(id,items);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return RedirectToAction(nameof(Index));
        }
    }
    
}
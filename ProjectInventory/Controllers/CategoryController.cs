using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProjectInventory.Dto;
using ProjectInventory.Models;
using ProjectInventory.Repository.Interface;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Controllers;

public class CategoryController:Controller
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryService _service;

    public CategoryController(ICategoryRepository repository,ICategoryService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
            var categoryItems = await _repository.GetAllAsync();
            return View(categoryItems);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        try
        {
            var categoryList = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = vm.Name,
                Description = vm.Description,
                IsActive = true
            };
            var isCreated = await _service.CreateAsync(categoryList);
            if (!isCreated)
            {
                return View(vm);
            }
        }
        catch (DbUpdateException ex1)
        {
            if (ex1.InnerException is PostgresException pgex)
            {
                Console.WriteLine("A postgres error occured: " + pgex.SqlState);
            }

            Console.WriteLine("An unexpected error occured: " + ex1.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("An unexpected error occured..." + ex.Message);
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        var vm = new CategoryEditVm
        {
            Name = item.Name,
            Description = item.Description,
            IsActive = item.IsActive
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id,CategoryEditVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
    
        try
        {
            var categorylist = new CategoryDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                IsActive = vm.IsActive
            };
            await _service.EditAsync(id,categorylist);
        }
        catch (Exception ex)
        {
            return View(vm);
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Remove(Guid id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

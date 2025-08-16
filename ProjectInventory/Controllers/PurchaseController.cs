using Microsoft.AspNetCore.Mvc;
using ProjectInventory.Dto;
using ProjectInventory.Entities;
using ProjectInventory.Models;
using ProjectInventory.Repository.Interface;
using ProjectInventory.Service.Interface;

namespace ProjectInventory.Controllers;

public class PurchaseController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IPurchaseService _purchaseService;
    private readonly IStockMovementService _stockMovementService;
    private readonly IStakeHolderRepository _stakeHolderRepository;

    public PurchaseController(IStakeHolderRepository stakeHolderRepository, IStockMovementService stockMovementService, IPurchaseService purchaseService, IProductRepository productRepository)
    {
        _stakeHolderRepository = stakeHolderRepository;
        _stockMovementService = stockMovementService;
        _purchaseService = purchaseService;
        _productRepository = productRepository;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }


    public async Task<IActionResult> Create()
    {
        try
        {
            var vm = new PurchaseVm();
            vm.Products= await _productRepository.GetAllSelectListAsync();
            vm.StakeHolders = await _stakeHolderRepository.GetVendor();
            vm.TransactionDate = DateOnly.FromDateTime(DateTime.Now);
            var products = await _productRepository.GetAllAsync();
            vm.ProductUnitMap = products.ToDictionary(
                p=> p.Id.ToString(),
                p=> p.Unit.Symbol
            );
            return View(vm);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(PurchaseVm vm)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                vm.Products= await _productRepository.GetAllSelectListAsync();
                vm.StakeHolders = await _stakeHolderRepository.GetVendor();
                vm.TransactionDate = DateOnly.FromDateTime(DateTime.Now);
                var products = await _productRepository.GetAllAsync();
                vm.ProductUnitMap = products.ToDictionary(
                    p=> p.Id.ToString(),
                    p=> p.Unit.Symbol
                );
                return View(vm);
            }

            var purchaseDto = new PurchaseDto()
            {
                InvoiceNumber = vm.InvoiceNumber,
                TransactionDate = vm.TransactionDate,
                StakeholderId = vm.StakeholderId,
                TotalAmount = vm.TotalAmount,
                Description = vm.Description,
                DiscountAmount = vm.DiscountAmount,
                TaxableAmount = vm.TaxableAmount,
                TaxAmount = vm.TaxAmount
            };
            var purchase = await _purchaseService.Create(purchaseDto);
            var stockMovementsDto = vm.StockMovements.Select(sm => new StockMovementDto
            {
                
                ProductId = sm.ProductId,
                Quantity = sm.Quantity,
                MovementType = MovementType.Purchase,
                InvoiceNumber = vm.InvoiceNumber,
                Rate = sm.Rate,
                Date = vm.TransactionDate,
                VatPercentage = sm.VatPercentage,
                TypeId = purchase.Id,
                Stock = Stock.In,
            }).ToList();
            await _stockMovementService.Create(stockMovementsDto);
            return RedirectToAction("Index");


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            vm.Products= await _productRepository.GetAllSelectListAsync();
            vm.StakeHolders = await _stakeHolderRepository.GetVendor();
            vm.TransactionDate = DateOnly.FromDateTime(DateTime.Now);
            var products = await _productRepository.GetAllAsync();
            vm.ProductUnitMap = products.ToDictionary(
                p=> p.Id.ToString(),
                p=> p.Unit.Symbol
            );
            return View(vm);
        }
    }

    
    
    
}
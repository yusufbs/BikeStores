using JC.Play.Common;
using JC.Play.Inventory.Service.Clients;
using JC.Play.Inventory.Service.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JC.Play.Inventory.Service.Controllers;

[ApiController]
[Route("items")]
public class ItemsController : Controller
{
    private readonly IRepository<InventoryItem> inventoryItemsRepository;
    private readonly IRepository<CatalogItem> catalogItemsRepository;

    public ItemsController(IRepository<InventoryItem> inventoryItemsRepository, IRepository<CatalogItem> catalogItemsRepository)
    {
        this.inventoryItemsRepository = inventoryItemsRepository;
        this.catalogItemsRepository = catalogItemsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
    {
        if(userId == Guid.Empty)
        {
            return BadRequest();
        }

        var inventoryItems = await inventoryItemsRepository.GetAllAsync(item => item.UserId == userId);
        var catalogItemIds = inventoryItems.Select(item => item.CatalogItemId);
        var catalogItems = await catalogItemsRepository.GetAllAsync(item => catalogItemIds.Contains(item.Id));

        var itemDtos = inventoryItems.Select(inventoryItem =>
        {
            var catalogItem = catalogItems.Single(c => c.Id == inventoryItem.CatalogItemId);
            return inventoryItem.AsDto(catalogItem.Name, catalogItem.Description);
        });
        return Ok(itemDtos);
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(GrantItemsDto grantItemsDto)
    {
        var inventoryItem = await inventoryItemsRepository.GetAsync(item =>
            item.UserId == grantItemsDto.UserId &&
            item.CatalogItemId == grantItemsDto.CatalogItemId);
        if (inventoryItem == null)
        {
            inventoryItem = new InventoryItem
            {
                UserId = grantItemsDto.UserId,
                CatalogItemId = grantItemsDto.CatalogItemId,
                Quantity = grantItemsDto.Quantity,
                AcquiredDate = DateTimeOffset.UtcNow
            };
            await inventoryItemsRepository.CreateAsync(inventoryItem);
        }
        else
        {
            inventoryItem.Quantity += grantItemsDto.Quantity;
            await inventoryItemsRepository.UpdateAsync(inventoryItem);
        }
        return Ok();
    }
}

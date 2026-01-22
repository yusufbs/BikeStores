using JC.Play.Common;
using JC.Play.Inventory.Service.Clients;
using JC.Play.Inventory.Service.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JC.Play.Inventory.Service.Controllers;

[ApiController]
[Route("items")]
public class ItemsController : Controller
{
    private readonly IRepository<InventoryItem> _repository;
    private readonly CatalogClient catalogClient;

    public ItemsController(IRepository<InventoryItem> repository, CatalogClient catalogClient)
    {
        _repository = repository;
        this.catalogClient = catalogClient;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
    {
        if(userId == Guid.Empty)
        {
            return BadRequest();
        }
        //var items = await _repository.GetAllAsync(item => item.UserId == userId);
        //var itemDtos = items.Select(item => item.AsDto());

        var catalogItems = await catalogClient.GetCatalogItemsAsync();
        var inventoryItems = await _repository.GetAllAsync(item => item.UserId == userId);
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
        var inventoryItem = await _repository.GetAsync(item =>
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
            await _repository.CreateAsync(inventoryItem);
        }
        else
        {
            inventoryItem.Quantity += grantItemsDto.Quantity;
            await _repository.UpdateAsync(inventoryItem);
        }
        return Ok();
    }
}

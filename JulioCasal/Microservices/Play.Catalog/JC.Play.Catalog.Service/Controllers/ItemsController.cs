using JC.Play.Catalog.Service.Entities;
using JC.Play.Common;
using Microsoft.AspNetCore.Mvc;

namespace JC.Play.Catalog.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Item> repository;

        public ItemsController(IRepository<Item> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = await repository.GetAllAsync();
            return items.Select(item => item.AsDto());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await repository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            await repository.CreateAsync(item.AsEntity());
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await repository.GetAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;
            
            await repository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id) 
        {
            var existingItem = await repository.GetAsync(id);
            if (existingItem == null)
            {
               return NotFound();
            }
            await repository.RemoveAsync(existingItem.Id);

            return NoContent();
        }
    }
}

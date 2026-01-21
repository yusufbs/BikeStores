using JC.Play.Catalog.Service.Entities;

namespace JC.Play.Catalog.Service.Repositories
{
    public interface IItemsRepository
    {
        Task CreateAsync(Item item);
        Task<IReadOnlyCollection<Item>> GetAllAsync();
        Task<Item> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Item item);
    }
}
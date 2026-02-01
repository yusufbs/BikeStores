using JC.Play.Catalog.Contracts;
using JC.Play.Common;
using JC.Play.Inventory.Service.Entities;
using MassTransit;

namespace JC.Play.Inventory.Service.Consumers;

public class CatalogItemDeletedConsumer : IConsumer<CatalogItemDeleted>
{
    public readonly IRepository<CatalogItem> repository;

    public CatalogItemDeletedConsumer(IRepository<CatalogItem> repository)
    {
        this.repository = repository;
    }
    public async Task Consume(ConsumeContext<CatalogItemDeleted> context)
    {
        var message = context.Message;
        var item = await repository.GetAsync(message.ItemId);
        if (item == null) 
        {
            return;
        }
        
        await repository.RemoveAsync(message.ItemId);
    }
}

using JC.Play.Catalog.Contracts;
using JC.Play.Common;
using JC.Play.Inventory.Service.Entities;
using MassTransit;

namespace JC.Play.Inventory.Service.Consumers;

public class CatalogItemCreatedConsumer : IConsumer<CatalogItemCreated>
{
    public readonly IRepository<CatalogItem> repository;

    public CatalogItemCreatedConsumer(IRepository<CatalogItem> repository)
    {
        this.repository = repository;
    }
    public async Task Consume(ConsumeContext<CatalogItemCreated> context)
    {
        var message = context.Message;
        var item = await repository.GetAsync(message.ItemId);
        if (item != null) 
        { 
            return;
        }

        item = new CatalogItem
        {
            Id = message.ItemId,
            Name = message.Name,
            Description = message.Description
        };

        await repository.CreateAsync(item);
    }
}

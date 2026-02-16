using OrderApi.Application.DTOs;
using OrderApi.Application.DTOs.Conversions;
using OrderApi.Application.Interfaces;
using Polly.Registry;
using System.Net.Http.Json;

namespace OrderApi.Application.Services;

public class OrderService(
        IOrder orderInterface,
        HttpClient httpClient,
        ResiliencePipelineProvider<string> resiliencePipeline) : IOrderService
{
    public async Task<ProductDTO> GetProduct(int productId)
    {
        var getProduct = await httpClient.GetAsync($"/api/products/{productId}");
        if (!getProduct.IsSuccessStatusCode)
            return null!;

        var product = await getProduct.Content.ReadFromJsonAsync<ProductDTO>();
        return product!;
    }

    public async Task<AppUserDTO> GetUser(int userId)
    {
        // var getUser = await httpClient.GetAsync($"/api/products/{userId}");
        var getUser = await httpClient.GetAsync($"http://localhost:5000/api/authentication/{userId}"); 
        if (!getUser.IsSuccessStatusCode)
            return null!;

        var user = await getUser.Content.ReadFromJsonAsync<AppUserDTO>();
        return user!;
    }

    public async Task<OrderDetailsDTO> GetOrderDetails(int OrderId)
    {
        var order = await orderInterface.FindByIdAsync(OrderId);
        if (order is null || order!.Id <= 0)
            return null!;

        var retryPipeline = resiliencePipeline.GetPipeline("my-retry-pipeline");

        var productDTO = retryPipeline.ExecuteAsync(async token => await GetProduct(order.ProductId));

        var appUserDTO = retryPipeline.ExecuteAsync(async token => await GetUser(order.ClientId));

        return new OrderDetailsDTO(
            order.Id,
            productDTO.Result.Id,
            appUserDTO.Result.Id,
            appUserDTO.Result.Name,
            appUserDTO.Result.Email,
            appUserDTO.Result.Address,
            appUserDTO.Result.TelephoneNumber,
            productDTO.Result.Name,
            order.PurchaseQuantity,
            productDTO.Result.Price,
            productDTO.Result.Price * order.PurchaseQuantity,
            order.OrderedDate
            );
    }

    public async Task<IEnumerable<OrderDTO>> GetOrdersByClientId(int clientId)
    {
        var orders = await orderInterface.GetOrdersAsync(o => o.ClientId == clientId);
        if (!orders.Any())
            return null!;

        return orders.ToDto();
    }
}

using eCommerce.SharedLibrary.Responses;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.DTOs;
using ProductApi.Application.DTOs.Conversions;
using ProductApi.Application.Interfaces;

namespace ProductApi.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProduct productInterface) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var products = await productInterface.GetAllAsync();
        if (!products.Any())
            return NotFound("No product detected in the database");

        var list = products.ToDTO();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var product = await productInterface.FindByIdAsync(id);
        if (product is null)
            return NotFound("Product requested not found");

        var dto = product.ToDTO();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<Response>> CreateProduct(ProductDTO product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var getEntity = product.ToEntity();
        var response = await productInterface.CreateAsync(getEntity);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response>> UpdateProduct(ProductDTO product)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var getEntity = product.ToEntity();
        var response = await productInterface.UpdateAsync(getEntity);

        return response.Flag ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    public async Task<ActionResult<Response>> DeleteProduct(ProductDTO product)
    {
        var getEntity = product.ToEntity();
        var response = await productInterface.DeleteAsync(getEntity);

        return response.Flag ? Ok(response) : BadRequest(response);
    }
}

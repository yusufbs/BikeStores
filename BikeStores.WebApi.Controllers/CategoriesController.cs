using Microsoft.AspNetCore.Mvc;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Controllers;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : GenericController<Category>
{
    public CategoriesController(IGenericRepository<Category> repository) : base(repository) { }
}

using Microsoft.AspNetCore.Mvc;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Controllers;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoresController : GenericController<Store>
{
    public StoresController(IGenericRepository<Store> repository) : base(repository) { }
}

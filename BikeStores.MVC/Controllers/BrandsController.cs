using Microsoft.AspNetCore.Mvc;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers
{
    public class BrandsController : BaseController<Brand>
    {
        public BrandsController(IGenericRepository<Brand> repository) : base(repository) { }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BrandId,BrandName")] Brand brand)
        {
            return CreatePost(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("BrandId,BrandName")] Brand brand)
        {
            return EditPost(brand, id == brand.BrandId, brand.BrandId);
        }
    }
}

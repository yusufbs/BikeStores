using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers
{
    public class StocksController : BaseController<Stock>
    {
        private readonly IDataRepository _dataRepository;

        public StocksController(IGenericRepository<Stock> repository, IDataRepository dataRepository) : base(repository)
        {
            _dataRepository = dataRepository;
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StoreId,ProductId,Quantity")] Stock stock)
        {
            return CreatePost(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("StoreId,ProductId,Quantity")] Stock stock)
        {
            return EditPost(stock, true, stock.StoreId);
        }

        public override void PopulateViewData(Stock? entity = null)
        {
            if (entity == null)
            {
                ViewData["ProductId"] = new SelectList(_dataRepository.GetProducts(), "ProductId", "ProductName");
                ViewData["StoreId"] = new SelectList(_dataRepository.GetStores(), "StoreId", "StoreName");
            }
            else
            {
                ViewData["ProductId"] = new SelectList(_dataRepository.GetProducts(), "ProductId", "ProductName", entity.ProductId);
                ViewData["StoreId"] = new SelectList(_dataRepository.GetStores(), "StoreId", "StoreName", entity.StoreId);
            }
        }

    }
}

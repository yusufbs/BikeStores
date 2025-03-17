using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeStores.Domain.Models;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers
{
    public class CustomersController : BaseController<Customer>
    {
        public CustomersController(IGenericRepository<Customer> repository) : base(repository) {}

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId,FirstName,LastName,Phone,Email,Street,City,State,ZipCode")] Customer customer)
        {
            return CreatePost(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CustomerId,FirstName,LastName,Phone,Email,Street,City,State,ZipCode")] Customer customer)
        {
            var idCheck = id == customer.CustomerId;
            return EditPost(customer, idCheck, customer.CustomerId);
        }
    }
}

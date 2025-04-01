using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeStores.Domain.Models;
using BikeStores.Domain.Repositories;
using BikeStores.Presentation.Generic.Interfaces;

namespace BikeStores.MVC.Controllers;

public class StaffsController : BaseController<Staff>
{
    private readonly IDataRepository _dataRepository;

    public StaffsController(IGenericRepository<Staff> repository, IDataRepository dataRepository) : base(repository)
    {
        _dataRepository = dataRepository;
    }

    // POST: Staffs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("StaffId,FirstName,LastName,Email,Phone,Active,StoreId,ManagerId")] Staff staff)
    {
        return CreatePost(staff);
    }

    // POST: Staffs/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("StaffId,FirstName,LastName,Email,Phone,Active,StoreId,ManagerId")] Staff staff)
    {
        return EditPost(staff, id == staff.StaffId, staff.StaffId);
    }

    public override void PopulateViewData(Staff? entity = null)
    {
        if (entity == null)
        {
            ViewData["ManagerId"] = new SelectList(_dataRepository.GetStaffs(), "StaffId", "Email");
            ViewData["StoreId"] = new SelectList(_dataRepository.GetStores(), "StoreId", "StoreName");
        }
        else
        {
            ViewData["ManagerId"] = new SelectList(_dataRepository.GetStaffs(), "StaffId", "Email", entity.ManagerId);
            ViewData["StoreId"] = new SelectList(_dataRepository.GetStores(), "StoreId", "StoreName", entity.StoreId);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskWersta.Data;
using TestTaskWersta.Models;

namespace TestTaskWersta.Controllers;

public class OrdersController : Controller
{
    private readonly AppDbContext _db;
    private readonly IOrderNumberGenerator _orderNumberGenerator;

    public OrdersController(AppDbContext context, IOrderNumberGenerator orderNumberGenerator)
    {
        _db = context;
        _orderNumberGenerator = orderNumberGenerator;
    }

 

    public async Task<IActionResult> Index()
    {
        var orders = await _db.Orders.OrderByDescending(o => o.CreatedAtUtc).ToListAsync();
        return View(orders);
    }



   
    public IActionResult Create()
    {
        return View();
    }



   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrderViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.PickupDate < DateOnly.FromDateTime(DateTime.Today))
        {
            ModelState.AddModelError(nameof(model.PickupDate), "Дата забора физически не может быть в прошлом!!!");
            return View(model);
        }

        var order = new Order
        {
            OrderNumber = _orderNumberGenerator.Generate(),
            SenderCity = model.SenderCity,
            SenderAddress = model.SenderAddress,
            RecipientCity = model.RecipientCity,
            RecipientAddress = model.RecipientAddress,
            Weight = model.Weight,
            PickupDate = model.PickupDate,
            CreatedAtUtc = DateTime.UtcNow
        };

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    
    public async Task<IActionResult> Details(int id)
    {
        var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }


    public IActionResult Error() => View("Error");
}
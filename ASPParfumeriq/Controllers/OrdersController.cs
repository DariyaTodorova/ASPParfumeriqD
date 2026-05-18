using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPParfumeriq.Data;
using ASPParfumeriq.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ASPParfumeriq.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Customer> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Cart()
        {
            var userId = _userManager.GetUserId(User);

            var orders = await _context.Orders
                .Include(o => o.Products)
                .Where(o => o.CustomerId == userId)
                .ToListAsync();

            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var orders = _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.Products);

            return View(await orders.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int productId, int orderQuantity = 1)
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            if (orderQuantity <= 0)
            {
                orderQuantity = 1;
            }

            var order = new Order
            {
                ProductId = productId,
                CustomerId = userId,
                OrderQuantity = orderQuantity,
                RegisterOn = DateTime.Now
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders.FindAsync(id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.Id) return NotFound();

            var existingOrder = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingOrder == null) return NotFound();

            order.CustomerId = existingOrder.CustomerId;
            order.RegisterOn = existingOrder.RegisterOn;

            ModelState.Remove("Products");
            ModelState.Remove("Customers");
            ModelState.Remove("CustomerId");

            if (ModelState.IsValid)
            {
                _context.Update(order);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }
        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User);

            var orders = await _context.Orders
                .Include(o => o.Products)
                .Where(o => o.CustomerId == userId)
                .ToListAsync();

            if (!orders.Any())
            {
                return RedirectToAction(nameof(Cart));
            }

            ViewBag.Total = orders.Sum(o => o.Products.Price * o.OrderQuantity);

            return View(orders);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Cart));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
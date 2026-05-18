using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPParfumeriq.Data;
using ASPParfumeriq.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPParfumeriq.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string? category, string? type)
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.TypeParfume)
                .AsQueryable();

            // CATEGORY FILTER

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Name == category);
            }

            // TYPE FILTER

            if (!string.IsNullOrEmpty(type))
            {
                if (type == "Парфюми")
                {
                    products = products.Where(p =>
                        p.Category.Name == "Мъжки" ||
                        p.Category.Name == "Дамски");
                }

                if (type == "Комплекти")
                {
                    products = products.Where(p =>
                        p.Category.Name == "Подаръчни комплекти");
                }

                if (type == "Луксозни")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Луксозни");
                }

                if (type == "Спортни")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Спортни");
                }

                if (type == "Дървесни")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Дървесни");
                }

                if (type == "Флорални")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Флорални");
                }

                if (type == "Амбров")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Амбров");
                }

                if (type == "Гурме")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Гурме");
                }

                if (type == "Мъжки комплект")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Мъжки комплект");
                }

                if (type == "Дамски комплект")
                {
                    products = products.Where(p =>
                        p.TypeParfume.Name == "Дамски комплект");
                }
            }

            return View(await products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.TypeParfume)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["TypeParfumeId"] = new SelectList(_context.TypeParfumes, "Id", "Name");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CategoryId,Quantity,TypeParfumeId,PhotoUrl,Price,Description")] Product product)
        {
            product.RegisterOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["TypeParfumeId"] = new SelectList(_context.TypeParfumes, "Id", "Name", product.TypeParfumeId);

            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["TypeParfumeId"] = new SelectList(_context.TypeParfumes, "Id", "Name", product.TypeParfumeId);

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Quantity,TypeParfumeId,PhotoUrl,Price,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            var existingProduct = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            product.RegisterOn = existingProduct.RegisterOn;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["TypeParfumeId"] = new SelectList(_context.TypeParfumes, "Id", "Name", product.TypeParfumeId);

            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.TypeParfume)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
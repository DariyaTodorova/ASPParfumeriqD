using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPParfumeriq.Data;
using ASPParfumeriq.Models;

namespace ASPParfumeriq.Controllers
{
    public class TypeParfumesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeParfumesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeParfumes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeParfumes.ToListAsync());
        }

        // GET: TypeParfumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeParfume = await _context.TypeParfumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeParfume == null)
            {
                return NotFound();
            }

            return View(typeParfume);
        }

        // GET: TypeParfumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeParfumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] TypeParfume typeParfume)
        {
            typeParfume.RegisterOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(typeParfume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeParfume);
        }

        // GET: TypeParfumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeParfume = await _context.TypeParfumes.FindAsync(id);
            if (typeParfume == null)
            {
                return NotFound();
            }
            return View(typeParfume);
        }

        // POST: TypeParfumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] TypeParfume typeParfume)
        {
            typeParfume.RegisterOn = DateTime.Now;
            if (id != typeParfume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeParfume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeParfumeExists(typeParfume.Id))
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
            return View(typeParfume);
        }

        // GET: TypeParfumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeParfume = await _context.TypeParfumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeParfume == null)
            {
                return NotFound();
            }

            return View(typeParfume);
        }

        // POST: TypeParfumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeParfume = await _context.TypeParfumes.FindAsync(id);
            if (typeParfume != null)
            {
                _context.TypeParfumes.Remove(typeParfume);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeParfumeExists(int id)
        {
            return _context.TypeParfumes.Any(e => e.Id == id);
        }
    }
}

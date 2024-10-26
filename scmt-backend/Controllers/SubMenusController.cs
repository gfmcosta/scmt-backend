using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using scmt_backend.Data;
using scmt_backend.Models;

namespace scmt_backend.Controllers
{
    public class SubMenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubMenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubMenus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Submenus.Include(s => s.Menu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submenu = await _context.Submenus
                .Include(s => s.Menu)
                .FirstOrDefaultAsync(m => m.id == id);
            if (submenu == null)
            {
                return NotFound();
            }

            return View(submenu);
        }

        // GET: SubMenus/Create
        public IActionResult Create()
        {
            ViewData["menuFK"] = new SelectList(_context.Menus, "id", "descricao");
            return View();
        }

        // POST: SubMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,visivel,menuFK")] Submenu submenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(submenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["menuFK"] = new SelectList(_context.Menus, "id", "descricao", submenu.menuFK);
            return View(submenu);
        }

        // GET: SubMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submenu = await _context.Submenus.FindAsync(id);
            if (submenu == null)
            {
                return NotFound();
            }
            ViewData["menuFK"] = new SelectList(_context.Menus, "id", "descricao", submenu.menuFK);
            return View(submenu);
        }

        // POST: SubMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,visivel,menuFK")] Submenu submenu)
        {
            if (id != submenu.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmenuExists(submenu.id))
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
            ViewData["menuFK"] = new SelectList(_context.Menus, "id", "descricao", submenu.menuFK);
            return View(submenu);
        }

        // GET: SubMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submenu = await _context.Submenus
                .Include(s => s.Menu)
                .FirstOrDefaultAsync(m => m.id == id);
            if (submenu == null)
            {
                return NotFound();
            }

            return View(submenu);
        }

        // POST: SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submenu = await _context.Submenus.FindAsync(id);
            if (submenu != null)
            {
                _context.Submenus.Remove(submenu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmenuExists(int id)
        {
            return _context.Submenus.Any(e => e.id == id);
        }
    }
}

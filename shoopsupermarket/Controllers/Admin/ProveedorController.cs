using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shoopsupermarket.Data;
using shoopsupermarket.Models;

namespace shoopsupermarket.Controllers
{
    //[Authorize(Roles="Admin")]
    public class ProveedorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proveedor
        [Route("Admin/{controller}")]
        public IActionResult Index()
        {
            return View(new Proveedor());
        }

        // GET: Proveedor/Details/5
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // GET: Proveedor/Create
        [Route("Admin/{controller}/{action}")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/{controller}/{action}")]
        public async Task<IActionResult> Create([Bind("ID,NAME,PHONE1,PHONE2")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                proveedor.NAME = proveedor.NAME.ToUpper();
                if(proveedor.PHONE2 == null)
                {
                    proveedor.PHONE2 = "N/A";
                }
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        // GET: Proveedor/Edit/5
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NAME,PHONE1,PHONE2")] Proveedor proveedor)
        {
            if (id != proveedor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(proveedor.PHONE2 == null)
                    {
                        proveedor.PHONE2 = "N/A";
                    }
                    proveedor.NAME = proveedor.NAME.ToUpper();
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.ID))
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
            return View(proveedor);
        }

        // GET: Proveedor/Delete/5
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Admin/{controller}/{action}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Data;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class FavorecidosController : Controller
    {
        private readonly RestauranteMVCContext _context;

        public FavorecidosController(RestauranteMVCContext context)
        {
            _context = context;
        }

        // GET: Favorecidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Favorecidos.ToListAsync());
        }

        // GET: Favorecidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorecidos = await _context.Favorecidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorecidos == null)
            {
                return NotFound();
            }

            return View(favorecidos);
        }

        // GET: Favorecidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Favorecidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,Nr,Cidade")] Favorecidos favorecidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorecidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favorecidos);
        }

        // GET: Favorecidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorecidos = await _context.Favorecidos.FindAsync(id);
            if (favorecidos == null)
            {
                return NotFound();
            }
            return View(favorecidos);
        }

        // POST: Favorecidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,Nr,Cidade")] Favorecidos favorecidos)
        {
            if (id != favorecidos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorecidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavorecidosExists(favorecidos.Id))
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
            return View(favorecidos);
        }

        // GET: Favorecidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorecidos = await _context.Favorecidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorecidos == null)
            {
                return NotFound();
            }

            return View(favorecidos);
        }

        // POST: Favorecidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorecidos = await _context.Favorecidos.FindAsync(id);
            _context.Favorecidos.Remove(favorecidos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavorecidosExists(int id)
        {
            return _context.Favorecidos.Any(e => e.Id == id);
        }
    }
}

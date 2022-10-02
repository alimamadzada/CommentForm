using CommentFrom.DAL;
using CommentFrom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvantagesController : Controller
    {
        private readonly AppDbContext _db;
        public AdvantagesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Advantages.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Advantage advantage)
        {
            if (ModelState.IsValid)
            {
                await _db.Advantages.AddAsync(advantage);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advantage);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            if (await _db.Advantages.FindAsync(id) == null) return NotFound();
            return View((await _db.Advantages.FindAsync(id) == null));
        }

        public async Task<IActionResult> Edit(int id, Service service)
        {
            if (id != service.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(service);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            return View(await _db.Advantages.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advantage = await _db.Advantages.FindAsync(id);
            _db.Advantages.Remove(advantage);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            Advantage advantage = await _db.Advantages.FirstOrDefaultAsync(x => x.Id == id);
            if (advantage == null) return NotFound();
            return View(advantage);
        }
    }
}
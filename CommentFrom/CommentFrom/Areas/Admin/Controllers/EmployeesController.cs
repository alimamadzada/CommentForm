using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommentFrom.DAL;
using CommentFrom.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Ali.Helpers;

namespace CommentFrom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Admin/Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Admin/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Admin/Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (employee.Img.IsSmallerThan(400) || !employee.Img.IsImage())
            {
                ModelState.AddModelError("Img", "File is not valid!");
                return View();
            }
            string path = _env.WebRootPath + @"\img\team\";
            employee.Image = await employee.Img.Upload(path);

            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }
            if (employee.Img != null)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                if (employee.Img.IsSmallerThan(400) || !employee.Img.IsImage())
                {
                    ModelState.AddModelError("Img", "File is not valid!");
                    return View();
                }

                string path = _env.WebRootPath + @"\img\team\";

                if (System.IO.File.Exists(Path.Combine(path, employee.Image)))
                    System.IO.File.Delete(Path.Combine(path, employee.Image));

                employee.Image = await employee.Img.Upload(path);
            }

            _context.Update(employee);
            await _context.SaveChangesAsync();

            return View(employee);
        }

        // GET: Admin/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Admin/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            string path = _env.WebRootPath + @"\img\team\";
            string filename = employee.Image;
            string final = Path.Combine(path, filename);
            if (System.IO.File.Exists(final))
                System.IO.File.Delete(final);

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}

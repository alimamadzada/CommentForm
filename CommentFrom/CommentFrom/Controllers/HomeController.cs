using CommentFrom.DAL;
using CommentFrom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new()
            {
                Services = await db.Services.Include(x => x.ServiceCategory).OrderByDescending(x => x).Take(3).ToListAsync(),
                Advantages = await db.Advantages.Take(3).ToListAsync(),
            };
            return View(hvm);
        }

        public async Task<IActionResult> Services()
        {
            ViewBag.serviceCount = db.Services.Count();
            return View(await db.Services.Include(x => x.ServiceCategory).OrderByDescending(x => x.Id).Take(3).ToListAsync());

        }
        public async Task<IActionResult> LoadMoreServices(int skip)
        {
            return PartialView("_ServicePartial", await db.Services.Include(x => x.ServiceCategory).OrderByDescending(x => x.Id).Skip(skip).Take(3).ToListAsync());
        }
        [Route("/filter")]
        public IActionResult SearchService()
        {
            return View();
        }
        public async Task<IActionResult> SearchServiceAjax(string query)
        {
            return PartialView("_ServicePartial", await db.Services.Include(x => x.ServiceCategory).Where(x => x.Title.ToLower().Contains(query.ToLower())).ToListAsync());
        }


    }
}
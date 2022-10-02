using CommentFrom.DAL;
using CommentFrom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.ViewComponents
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly AppDbContext db;
        public TeamViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Employee> model = await db.Employees.ToListAsync();
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        dbcontext db;
        public HomeController(dbcontext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            var result = db.Thecatogry.ToList();
            return View(result);
        }
        public IActionResult contactus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult savecontact(tocontactus modl)
        {
            db.tocontactus.Add(modl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult massag()
        {

            return View(db.tocontactus.ToList());
        }
        public IActionResult news(int Id)
        {
           thecatogry c = db.Thecatogry.Find(Id);
            ViewBag.d = c.Name;
            var resulte = db.thenews.Where(x => x.thecatogryId == Id).OrderByDescending(x => x.thedate).ToList();
            return View(resulte);
        }

        public IActionResult deletenews(int Id)
        {
            var result = db.thenews.Find(Id);
            db.thenews.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult team_mmber()
        {
           
            return View( db.Theteam.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

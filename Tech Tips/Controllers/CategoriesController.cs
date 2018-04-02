using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tech_Tips.Models;

namespace Tech_Tips.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tech_Tips.Models;

namespace Tech_Tips.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext _context;

        public ArticlesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Articles
        public ActionResult Index()
        {
            var articles = _context.Articles.Include(c => c.Category).ToList();
            return View(articles);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            var article = _context.Articles.Include(c => c.Category).SingleOrDefault(c => c.Id == id);

            if (article == null)
                return HttpNotFound();
            return View(article);
        }
    }
}

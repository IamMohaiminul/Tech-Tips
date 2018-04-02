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

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tech_Tips.Models;
using Tech_Tips.ViewModels;

namespace Tech_Tips.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationDbContext _context;

        public BlogsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Blogs
        public ActionResult Index()
        {
            var blogs = _context.Blogs.Include(b => b.Category).ToList();

            return View(blogs);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();

            var blogFormViewModel = new BlogFormViewModel()
            {
                Categories = categories
            };

            return View("BlogForm", blogFormViewModel);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int id)
        {
            var blog = _context.Blogs.Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            if (blog == null)
                return HttpNotFound();

            var blogFormViewModel = new BlogFormViewModel()
            {
                Categories = _context.Categories.ToList(),
                Blog = blog
            };

            return View("BlogForm", blogFormViewModel);
        }

        // POST: Blogs/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                var blogFormViewModel = new BlogFormViewModel()
                {
                    Categories = _context.Categories.ToList(),
                    Blog = blog
                };

                return View("BlogForm", blogFormViewModel);
            }

            try
            {
                // TODO: Add insert / edit logic here
                if (blog.Id == 0)
                {
                    _context.Blogs.Add(blog);
                }
                else
                {
                    var blogInDb = _context.Blogs.Single(model => model.Id == blog.Id);
                    //TryUpdateModel(blogInDb);
                    blogInDb.Title = blog.Title;
                    blogInDb.Description = blog.Description;
                    blogInDb.CategoryId = blog.CategoryId;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Blogs");
            }
            catch
            {
                return View("BlogForm");
            }
        }
    }
}
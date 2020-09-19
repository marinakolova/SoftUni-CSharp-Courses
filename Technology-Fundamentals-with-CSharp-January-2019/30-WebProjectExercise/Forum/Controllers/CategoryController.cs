using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ForumDbContext context;

        public CategoryController(ForumDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Category category)
        {
            string authorId = context.Users
                .Where(u => u.UserName == this.User.Identity.Name)
                .First()
                .Id;
            category.AuthorId = authorId;

            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(category);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Category category = context.Categories
                .Include(t => t.Author)
                .Include(t => t.Topics)
                .ThenInclude(c => c.Author)
                .Where(t => t.Id == id)
                .SingleOrDefault();

            if (category == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Category> categories = context
                .Categories
                .Include(c => c.Author)
                .Include(c => c.Topics)
                .ToList();

            ViewData["Categories"] = categories;
            return View(category);
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Category category = context.Categories
                .Where(t => t.Id == id)
                .Include(c => c.Author)
                .SingleOrDefault();

            if (category == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!category.IsAuthor(User.Identity.Name))
            {
                return Forbid();
            }

            return View(category);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                Category categoryFromDb = context.Categories
                    .Include(c => c.Author)
                    .SingleOrDefault(t => t.Id.Equals(category.Id));

                if (categoryFromDb == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                categoryFromDb.Name = category.Name;

                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(category);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Category category = context.Categories
                .Include(c => c.Author)
                .SingleOrDefault(c => c.Id == id);

            if (category == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!category.IsAuthor(User.Identity.Name))
            {
                return Forbid();
            }

            return View(category);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            Category category = context.Categories
                .Include(c => c.Author)
                .SingleOrDefault(c => c.Id == id);

            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }

            return RedirectPermanent("/");
        }
    }
}
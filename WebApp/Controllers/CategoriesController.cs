﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories= CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";

           var category = CategoriesRepository.GetCategoryById(id.HasValue? id.Value: 0);

           return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category) 
        {
            if (ModelState.IsValid)
            {
            CategoriesRepository.UpdateCategory(category.CategoryID, category);
            return RedirectToAction(nameof(Index));             
            }
            return View(category);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int CategoryID) 
        {
            CategoriesRepository.DeleteCategory(CategoryID);
            return RedirectToAction(nameof(Index));
        }
    }
}

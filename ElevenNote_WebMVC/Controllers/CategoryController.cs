using ElevenNote_Models;
using ElevenNote_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote_WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        [Authorize]
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryService();
            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your category was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Category could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCategoryService();
            var detail = service.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    CategoryId = detail.CategoryId,
                    Subject = detail.Subject
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCategoryService();
            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your category was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your category could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCategoryService();

            service.DeleteCategory(id);
            TempData["SaveResult"] = "Your category was deleted";
            return RedirectToAction("Index");
        }
        private CategoryService CreateCategoryService()
        {
            var service = new CategoryService();
            return service;
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Services;

namespace PeopleApp.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var result = await _repo.GetAsync();
            if (result.Succeeded)
            {
                return View(result.Entities);
            }
            return View(Enumerable.Empty<Department>());
        }


        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Department department)
        {

        }

        // POST: DepartmentController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

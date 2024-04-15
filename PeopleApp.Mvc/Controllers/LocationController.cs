using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Services;

namespace PeopleApp.Mvc.Controllers
{
    public class LocationController : Controller
    {
        ILocationRepository _repo;
        public LocationController(ILocationRepository repo)
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
            return View(Enumerable.Empty<Location>());
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        public ActionResult Edit(int id)
        {
            return View();
        }

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


        public ActionResult Delete(int id)
        {
            return View();
        }

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

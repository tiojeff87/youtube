using Microsoft.AspNetCore.Mvc;
using Youtube.Domain.Entities;
using Youtube.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Youtube.web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Youtube.web.Controllers
{
    public class YoutuberRecordsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public YoutuberRecordsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var YoutuberRecords = _db.YoutuberRecords
                .Include(u => u.Youtuber)
                .ToList();

            return View(YoutuberRecords);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(YoutuberRecords obj)
        {
            if (ModelState.IsValid)
            {
                _db.YoutuberRecords.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The Youtuber Records has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Youtuber Records could not be created.";
            return View(obj);
        }
        public IActionResult Update(int villaId)
        {
            Youtuber? obj = _db.Youtubers.FirstOrDefault(_ => _.Id == villaId);

            //Villa? obj2 = _db.Villas.Find(villaId);
            //var VillaList = _db.Villas.Where(_ => _.Price > 50 && _.Occupancy > 0);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Youtuber obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _db.Youtubers.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The villa has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The villa could not be updated.";
            return View(obj);
        }

        public IActionResult Delete(int villaId)
        {
            Youtuber? obj = _db.Youtubers.FirstOrDefault(_ => _.Id == villaId);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Youtuber obj)
        {
            Youtuber? objFromDb = _db.Youtubers.FirstOrDefault(_ => _.Id == obj.Id);

            if (objFromDb is not null)
            {
                _db.Youtubers.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "The villa has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The villa could not be deleted.";
            return View(obj);
        }
    }
}

﻿using Youtube.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain.Entities;

namespace Youtube.web.Controllers
{
    public class YoutuberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public YoutuberController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var youtube = _db.Youtubers.ToList();

            return View(youtube);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Youtuber obj)
        {

            if (ModelState.IsValid)
            {
                _db.Youtubers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The Youtuber has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Youtuber could not be created.";
            return View(obj);
        }

        public IActionResult Update(int YoutuberId)
        {
            Youtuber? obj = _db.Youtubers.FirstOrDefault(_ => _.Id == YoutuberId);

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
                TempData["success"] = "The Youtuber has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The villa could not be updated.";
            return View(obj);
        }

        public IActionResult Delete(int YoutuberId)
        {
            Youtuber? obj = _db.Youtubers.FirstOrDefault(_ => _.Id == YoutuberId);

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

                TempData["success"] = "The Youtuber has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Youtuber could not be deleted.";
            return View(obj);
        }
    }
}

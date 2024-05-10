using Youtube.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Youtube.Domain.Entities;
using Youtube.Application.Common.Interfaces;
using Youtube.Infrastructure.Repository;

namespace Youtube.web.Controllers
{
    public class YoutuberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public YoutuberController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var youtube = _unitOfWork.Youtuber.GetAll();

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
                _unitOfWork.Youtuber.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "The Youtuber has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Youtuber could not be created.";
            return View(obj);
        }

        public IActionResult Update(int YoutuberId)
        {
            Youtuber? obj = _unitOfWork.Youtuber.Get(_ => _.Id == YoutuberId);

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
                _unitOfWork.Youtuber.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "The Youtuber has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The villa could not be updated.";
            return View(obj);
        }

        public IActionResult Delete(int YoutuberId)
        {
            Youtuber? obj = _unitOfWork.Youtuber.Get(_ => _.Id == YoutuberId);

            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Youtuber obj)
        {
            Youtuber? objFromDb = _unitOfWork.Youtuber.Get(_ => _.Id == obj.Id);

            if (objFromDb is not null)
            {
                _unitOfWork.Youtuber.Remove(obj);
                _unitOfWork.Save();

                TempData["success"] = "The Youtuber has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The Youtuber could not be deleted.";
            return View(obj);
        }
    }
}

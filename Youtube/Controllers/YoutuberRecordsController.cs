using Microsoft.AspNetCore.Mvc;
using Youtube.Domain.Entities;
using Youtube.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Youtube.web.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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
            youtuberRecordsVM youtuberRecordsVM = new()
            {
                YoutuberList = _db.Youtubers.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            return View(youtuberRecordsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(youtuberRecordsVM obj)
        {
            if (ModelState.IsValid)
            {
                bool roomNumberExists = _db.YoutuberRecords.Any(u => u.Votos == obj.YoutuberRecords.Votos);

                if (!roomNumberExists)
                {
                    // Remove the explicit setting of the Votos property
                    obj.YoutuberRecords.Votos = 0; // Or any default value if necessary

                    _db.YoutuberRecords.Add(obj.YoutuberRecords);
                    _db.SaveChanges();
                    TempData["success"] = "The villa number has been created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = "A Youtuber record with the same Votos value already exists.";
                }
            }

            // Re-populate the YoutuberList property
            obj.YoutuberList = _db.Youtubers.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }).ToList();

            return View(obj);
        }
        public IActionResult Update(int youtuberRecordsId)
        {
            youtuberRecordsVM viewModel = new youtuberRecordsVM
            {
                YoutuberList = _db.Youtubers
                    .Select(y => new SelectListItem
                    {
                        Text = y.Name,
                        Value = y.Id.ToString()
                    })
                    .ToList(),
                YoutuberRecords = _db.YoutuberRecords.FirstOrDefault(y => y.Votos == youtuberRecordsId)
            };

            if (viewModel.YoutuberRecords == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(youtuberRecordsVM viewModel)
        {
            if (ModelState.IsValid && viewModel.YoutuberRecords != null)
            {
                _db.YoutuberRecords.Update(viewModel.YoutuberRecords);
                _db.SaveChanges();
                TempData["success"] = "The youtuber record has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The youtuber record could not be updated.";
            viewModel.YoutuberList = _db.Youtubers
                .Select(y => new SelectListItem
                {
                    Text = y.Name,
                    Value = y.Id.ToString()
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Delete(int youtuberRecordsId)
        {
            youtuberRecordsVM youtuberRecordsVM = new()
            {
                YoutuberList = _db.Youtubers.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                YoutuberRecords = _db.YoutuberRecords.FirstOrDefault(_ => _.Votos == youtuberRecordsId)!
            };

            if (youtuberRecordsVM.YoutuberRecords is null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(youtuberRecordsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(youtuberRecordsVM youtuberRecordsVM)
        {
            YoutuberRecords objFromDb = _db.YoutuberRecords
                .FirstOrDefault(_ => _.Votos == youtuberRecordsVM.YoutuberRecords.Votos);

            if (objFromDb is not null)
            {
                _db.YoutuberRecords.Remove(objFromDb);
                _db.SaveChanges();

                TempData["success"] = "The youtuber records has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The youtuber records could not be deleted.";
            return View(youtuberRecordsVM);
        }
    }
}

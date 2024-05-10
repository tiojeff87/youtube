using Microsoft.AspNetCore.Mvc;
using Youtube.Domain.Entities;
using Youtube.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Youtube.web.ViewModels;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using Youtube.Application.Common.Interfaces;

namespace Youtube.web.Controllers
{
    public class YoutuberRecordsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public YoutuberRecordsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var YoutuberRecords = _unitOfWork.YoutuberRecords.GetAll(includeProperties: "Youtuber");
            return View(YoutuberRecords);
        }

        public IActionResult Create()
        {
            youtuberRecordsVM youtuberRecordsVM = new()
            {
                YoutuberList = _unitOfWork.Youtuber.GetAll().Select(u => new SelectListItem
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
                bool roomNumberExists = _unitOfWork.YoutuberRecords.Any(u => u.Votos == obj.YoutuberRecords.Votos);

                if (!roomNumberExists)
                {
                    // Remove the explicit setting of the Votos property
                    obj.YoutuberRecords.Votos = 0; // Or any default value if necessary

                    _unitOfWork.YoutuberRecords.Add(obj.YoutuberRecords);
                    _unitOfWork.Save();

                    TempData["success"] = "The villa number has been created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = "A Youtuber record with the same Votos value already exists.";
                }
            }

            // Re-populate the YoutuberList property
            obj.YoutuberList = _unitOfWork.Youtuber.GetAll().Select(u => new SelectListItem
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
                YoutuberList = _unitOfWork.Youtuber.GetAll().Select(y => new SelectListItem
                    {
                        Text = y.Name,
                        Value = y.Id.ToString()
                    })
                    .ToList(),
                YoutuberRecords = _unitOfWork.YoutuberRecords.Get(y => y.Votos == youtuberRecordsId)
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
                _unitOfWork.YoutuberRecords.Update(viewModel.YoutuberRecords);
                _unitOfWork.Save();
                TempData["success"] = "The youtuber record has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The youtuber record could not be updated.";
            viewModel.YoutuberList = _unitOfWork.Youtuber.GetAll().Select(y => new SelectListItem
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
                YoutuberList = _unitOfWork.Youtuber.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                YoutuberRecords = _unitOfWork.YoutuberRecords.Get(_ => _.Votos == youtuberRecordsId)!
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
            YoutuberRecords objFromDb = _unitOfWork.YoutuberRecords.Get(_ => _.Votos == youtuberRecordsVM.YoutuberRecords.Votos);

            if (objFromDb is not null)
            {
                _unitOfWork.YoutuberRecords.Remove(objFromDb);
                _unitOfWork.Save();

                TempData["success"] = "The youtuber records has been deleted successfully.";

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The youtuber records could not be deleted.";
            return View(youtuberRecordsVM);
        }
    }
}

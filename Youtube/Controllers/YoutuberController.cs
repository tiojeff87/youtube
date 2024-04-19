using Microsoft.AspNetCore.Mvc;
using Youtube.Infrastructure.Data;

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
    }
}

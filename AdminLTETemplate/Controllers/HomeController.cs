using AdminLTETemplate.Entities;
using AdminLTETemplate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminLTETemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DatabaseContext _databaseContext;

        public HomeController(ILogger<HomeController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Albums()
        {
            return View(_databaseContext.Albums.ToList());
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album model)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Albums.Add(model);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Albums));
            }

            return View(model);
        }

        public IActionResult table()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
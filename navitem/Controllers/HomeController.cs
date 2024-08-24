using Microsoft.AspNetCore.Mvc;
using navitem.Models;
using System.Diagnostics;

namespace navitem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        private readonly IRepository<NavigationItem> _repository;

        public HomeController(IRepository<NavigationItem> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _repository.GetAllAsync();
            return View(items);
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
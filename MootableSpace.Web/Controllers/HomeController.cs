using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MootableSpace.Web.Models;
using System.Diagnostics;

namespace MootableSpace.Web.Controllers
{
    [Authorize(Roles ="Admin,Editor,User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> Share(int? id)
        //{
        //    var model = new MootEditViewModel();
        //    if (id.HasValue)
        //    {

        //    }
        //}
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
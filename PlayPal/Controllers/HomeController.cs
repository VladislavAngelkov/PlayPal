using Microsoft.AspNetCore.Mvc;
using PlayPal.Data.Models;
using PlayPal.Models;
using System.Diagnostics;

namespace PlayPal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (User.Identity != null && User.Identity.IsAuthenticated)
            //{
            //    if (User.IsInRole("Administrator"))
            //    {
            //        return RedirectToAction("Index", "Administrator", new { Area = "Administration" });
            //    }
            //    else if (User.IsInRole("FieldOwner"))
            //    {
            //        return RedirectToAction("Mine", "Field", new { Area = "FieldManagment" });
            //    }
            //    else if (User.IsInRole("Player"))
            //    {
            //        return RedirectToAction("All", "Game");
            //    }
            //    else
            //    {
            //        return View();
            //    }
            //}

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
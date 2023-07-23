using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Models;
using System.Diagnostics;

namespace PlayPal.Controllers
{
    public class HomeController : PlayPalBaseController
    {
        private readonly IPlayerService _playerService;
        private readonly IBanService _banService;
        private readonly SignInManager<PlayPalUser> _signinManager;

        public HomeController(
            IPlayerService playerService,
            IBanService banService,
            SignInManager<PlayPalUser> signinManager)
        {
            _playerService = playerService;
            _banService = banService;
            _signinManager = signinManager;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage", "Account");
            }

            var model = new LoginUserInputModel();
            model.returnUrl = returnUrl;

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
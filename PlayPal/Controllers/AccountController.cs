using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;
using System.Security.Claims;
using System.Text;

namespace PlayPal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IPositionService _positionService;

        public AccountController(
            IAccountService accountService,
            IPositionService positionService)
        {
            _accountService = accountService;
            _positionService = positionService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("JoinGame", "Game");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterAsPlayer()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("JoinGame", "Game");
            }

            var positions = await _positionService.GetAllPositionsModels();

            var model = new RegisterUserInputModel();
            model.Player = new CreatePlayerInputModel();
            model.Player.Positions = positions;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsPlayer(RegisterUserInputModel model)
        {
            var positions = await _positionService.GetAllPositionsModels();

            if (!positions.Any(p => p.Id == model.Player!.Position))
            {
                ModelState.AddModelError("", "Selected position does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Player!.Positions = positions;

                //var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));

                //return Ok(message);

                return View(model);
            }

            await _accountService.RegisterPlayerUserAsync(model);

            return RedirectToAction("JoinGame", "Game");
        }

        [HttpGet]
        public async Task<IActionResult> ApplyForAdministrator()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Administration", "Administrator", "Promote");
            }

            var model = new RegisterUserInputModel();
            var administrator = new CreateAdministratorInputModel();
            model.Administrator = administrator;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyForAdministrator(RegisterUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _accountService.ApplyAdministratorAsync(model);

            return View("Success");
        }
    }
}

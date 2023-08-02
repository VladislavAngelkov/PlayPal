using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Extensions;
using System.Text;

namespace PlayPal.Controllers
{
    [Authorize(Policy = PlayPalPolicyNames.Player)]
    public class PlayerController : PlayPalBaseController
    {
        private readonly IPlayerService _playerService;
        private readonly IPositionService _positionService;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly SignInManager<PlayPalUser> _signInManager;

        public PlayerController(
            IPlayerService playerService,
            IPositionService positionService,
            UserManager<PlayPalUser> userManager,
            SignInManager<PlayPalUser> signInManager)
        {
            _playerService = playerService;
            _positionService = positionService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> ViewProfile(Guid? playerId = null)
        {
            if (playerId == null)
            {
                playerId = (Guid)User.PlayerId()!;
            }

            try
            {
                var model = await _playerService.GetPlayerProfileViewModelAsync((Guid)playerId);

                if (model == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            Guid playerId = (Guid)User.PlayerId()!;
            string email = User.Identity!.Name!;
            try
            {
                var model = await _playerService.GetEditPlayerProfileInputModelAsync(playerId, email);

                if (model == null)
                {
                    return RedirectToAction("Error", "Home", new { Area = "" });
                }

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditPlayerProfileInputModel model)
        {
            var positions = await _positionService.GetAllPositionsModels();

            if (!positions.Any(p => model.Position == p.Id))
            {
                ModelState.AddModelError("", ErrorMessages.PositionDoesNotExist);
            }

            if (!ModelState.IsValid)
            {
                model.Positions = positions;

                return View(model);
            }

            try
            {
                Guid userId = User.UserId();

                await _signInManager.SignOutAsync();

                await _playerService.UpdatePlayer(model, userId);

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("ViewProfile");
                }

                else
                {
                    ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLogin);

                    return View(model);
                }
            }
            catch (Exception) { return RedirectToAction("Error", "Home"); }
        }
    }
}

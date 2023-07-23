using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Extensions;

namespace PlayPal.Controllers
{
    [Authorize(Policy = PlayPalPolicyNames.Player)]
    public class PlayerController : PlayPalBaseController
    {
        private readonly IPlayerService _playerService;
        private readonly IPositionService _positionService;
        private readonly IAccountService _accountService;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly SignInManager<PlayPalUser> _signInManager;

        public PlayerController(
            IPlayerService playerService,
            IPositionService positionService,
            IAccountService accountService,
            UserManager<PlayPalUser> userManager,
            SignInManager<PlayPalUser> signInManager)
        {
            _playerService = playerService;
            _positionService = positionService;
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            Guid playerId = (Guid)User.PlayerId()!;

            try
            {
                var player = await _playerService.GetPlayerAsync(playerId);

                if (player == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                var position = await _positionService.GetPositionByIdAsync(player.PositionId);

                var model = new PlayerProfileViewModel()
                {
                    Id = playerId,
                    Name = player.Name,
                    CurrentCity = player.CurrentCity,
                    Position = position.Name,
                    Games = player.Teams.Count,
                    Goals = player.Goals.Count
                };

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            Guid playerId = (Guid)User.PlayerId()!;

            try
            {
                var player = await _playerService.GetPlayerAsync(playerId);

                if (player == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                var positions = await _positionService.GetAllPositionsModels();

                var model = new EditPlayerProfileInputModel()
                {
                    Email = User.Identity.Name,
                    Id = playerId,
                    Name = player.Name,
                    CurrentCity = player.CurrentCity,
                    Position = player.PositionId,
                    Positions = positions
                };

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
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

                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLogin);

                    return View(model);
                }

                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

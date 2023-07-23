using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Common.StringFormats;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Extensions;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace PlayPal.Controllers
{
    public class AccountController : PlayPalBaseController
    {
        private readonly IAccountService _accountService;
        private readonly IPositionService _positionService;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly SignInManager<PlayPalUser> _signInManager;
        private readonly IPlayerService _playerService;
        private readonly IBanService _banService;

        public AccountController(
            IAccountService accountService,
            IPositionService positionService,
            UserManager<PlayPalUser> userManager,
            SignInManager<PlayPalUser> signInManager,
            IPlayerService playerService,
            IBanService banService)
        {
            _accountService = accountService;
            _positionService = positionService;
            _userManager = userManager;
            _signInManager = signInManager;
            _playerService = playerService;
            _banService = banService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterUserInputModel();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsPlayer(RegisterUserInputModel model)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                return RedirectToAction("Index", "Home");
            }

            if (await _accountService.UserExist(model.Email))
            {
                ModelState.AddModelError("", ErrorMessages.UsedEmail);
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register", model);
            }

            if (model.Player == null)
            {
                try
                {
                    var positions = await _positionService.GetAllPositionsModels();

                    model.Player = new CreatePlayerInputModel();
                    model.Player.Positions = positions;

                    return View(model);
                }
                catch (Exception)
                {

                    return RedirectToAction("Error", "Home");
                }
            }

            try
            {
                var positions = await _positionService.GetAllPositionsModels();

                if (!positions.Any(p => p.Id == model.Player!.Position))
                {
                    ModelState.AddModelError("", ErrorMessages.PositionDoesNotExist);
                }

                if (await _accountService.UserExist(model.Email))
                {
                    ModelState.AddModelError("", ErrorMessages.UsedEmail);
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

                var user = await _accountService.RegisterPlayerUserAsync(model);

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return Ok("Confirm your account");
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("JoinGame", "Game");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ApplyForAdministrator(RegisterUserInputModel model)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                return RedirectToAction("Index", "Home");
            }

            if (await _accountService.UserExist(model.Email))
            {
                ModelState.AddModelError("", ErrorMessages.UsedEmail);
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register", model);
            }

            if (model.Administrator == null)
            {
                model.Administrator = new CreateAdministratorInputModel();

                return View(model);
            }

            try
            {
                var user = await _accountService.ApplyAdministratorAsync(model);

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return Ok("Confirm your account");
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    TempData[ToastrMessageTypes.Success] = SuccessMessages.AdministratorSuccess;

                    return RedirectToAction("Index", "Administrator", new { area = "Administration" });
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsFieldOwner(RegisterUserInputModel model)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                return RedirectToAction("Index", "Home");
            }

            if (await _accountService.UserExist(model.Email))
            {
                ModelState.AddModelError("", ErrorMessages.UsedEmail);
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register", model);
            }

            if (model.FieldOwner == null)
            {
                model.FieldOwner = new CreateFieldOwnerInputModel();

                return View(model);
            }

            try
            {
                var user = await _accountService.RegisterFieldOwnerAsync(model);

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    return Ok("Confirm your account");
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Mine", "Field", "FieldManagment");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
                //return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Manage()
        {
            if (User.IsInRole(PlayPalRoleNames.Administrator))
            {
                return RedirectToAction("Index", "Administrator", new { Area = "Administration" });
            }
            else if (User.IsInRole(PlayPalRoleNames.FieldOwner))
            {
                return RedirectToAction("Mine", "Field", new { Area = "FieldManagment" });
            }
            else if (User.IsInRole(PlayPalRoleNames.Player))
            {
                return RedirectToAction("BanCheck", "Account");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("BanCheck");
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
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                await _signInManager.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> DeleteUser(AdministratorRequestViewModel model)
        {
            await _accountService.DeleteUser(model.UserId);

            return RedirectToAction("Promote", "Administrator", new { Area = "Administration" });
        }

        private bool IdentityCheck()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return true;
            }

            return false;
        }

        [HttpGet]
        public async Task<IActionResult> BanCheck()
        {
            if (User.IsInRole(PlayPalRoleNames.Player))
            {
                var playerId = (Guid)User.PlayerId()!;

                var player = await _playerService.GetPlayerAsync(playerId);

                if (player != null)
                {
                    var latestBan = await _banService.GetLatestBan(playerId);

                    if (latestBan != null && latestBan.BannedTo > DateTime.UtcNow)
                    {
                        await _signInManager.SignOutAsync();

                        TempData[ToastrMessageTypes.Warning] = String.Format(WarningMessages.Banned, latestBan.BannedTo.ToString(DateTimeFormats.BannedToFormat), latestBan.Reason);

                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("JoinGame", "Game");
                }

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        
    }
}

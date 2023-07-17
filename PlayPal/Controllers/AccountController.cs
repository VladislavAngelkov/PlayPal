using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Controllers
{
    public class AccountController : PlayPalBaseController
    {
        private readonly IAccountService _accountService;
        private readonly IPositionService _positionService;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly SignInManager<PlayPalUser> _signInManager;

        public AccountController(
            IAccountService accountService,
            IPositionService positionService,
            UserManager<PlayPalUser> userManager,
            SignInManager<PlayPalUser> signInManager)
        {
            _accountService = accountService;
            _positionService = positionService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RegisterAsPlayer(string? returnUrl)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            try
            {
                var positions = await _positionService.GetAllPositionsModels();

                var model = new RegisterUserInputModel();
                model.Player = new CreatePlayerInputModel();
                model.Player.Positions = positions;

                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsPlayer(RegisterUserInputModel model)
        {
            try
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
        [HttpGet]
        public IActionResult ApplyForAdministrator(string? returnUrl)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterUserInputModel();
            var administrator = new CreateAdministratorInputModel();
            model.Administrator = administrator;

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ApplyForAdministrator(RegisterUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
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

                    return RedirectToAction("Index", "Administrator", new {area="Administration"});
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RegisterAsFieldOwner(string? returnUrl)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterUserInputModel();
            var fieldOwner = new CreateFieldOwnerInputModel();
            model.FieldOwner = fieldOwner;

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsFieldOwner(RegisterUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
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
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Manage()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            bool isLogged = IdentityCheck();

            if (isLogged)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.AlreadyLogged;

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            var model = new LoginUserInputModel();
            model.returnUrl = returnUrl;

            return View(model);
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
                    if (model.returnUrl != null)
                    {
                        return LocalRedirect(model.returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
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

            return RedirectToAction("Promote", "Administrator", new {Area="Administration"});
        }

        private bool IdentityCheck()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return true;
            }

            return false;
        }
    }
}

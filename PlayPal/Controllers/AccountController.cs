using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Controllers
{
    public class AccountController : Controller
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

        [HttpGet]
        public IActionResult Register()
        {
            //IdentityCheck();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterAsPlayer()
        {
            IdentityCheck();

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

            var user = await _accountService.RegisterPlayerUserAsync(model);

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                return Ok("Confirm your account");
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return View("Register");

                //return RedirectToAction("JoinGame", "Game");
            }
        }

        [HttpGet]
        public IActionResult ApplyForAdministrator()
        {
            IdentityCheck();

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

            var user = await _accountService.ApplyAdministratorAsync(model);

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                return Ok("Confirm your account");
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return View("Success");
            }

        }

        [HttpGet]
        public IActionResult RegisterAsFieldOwner()
        {
            IdentityCheck();

            var model = new RegisterUserInputModel();
            var fieldOwner = new CreateFieldOwnerInputModel();
            model.FieldOwner = fieldOwner;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsFieldOwner(RegisterUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

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

        private IActionResult IdentityCheck()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Administrator"))
                {
                    return RedirectToAction("Promote", "Administrator", "Administration");
                }
                else if (User.IsInRole("FieldOwner"))
                {
                    return RedirectToAction("Mine", "Field", "FiledManagment");
                }
                else if (User.IsInRole("Player"))
                {
                    return RedirectToAction("JoinGame", "Game", new { City = User.Claims.First(c => c.ValueType == "City") });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

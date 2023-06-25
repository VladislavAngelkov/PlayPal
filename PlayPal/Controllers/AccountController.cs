using Microsoft.AspNetCore.Mvc;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models.Enums;
using System.Text;

namespace PlayPal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterAsPlayer()
        {
            var positions = new List<PositionViewModel>()
            {
                new PositionViewModel()
                {
                    Position = "GoalKeeper"
                },
                new PositionViewModel()
                {
                    Position = "FieldPlayer"
                },
            };

            var model = new CreatePlayerInputModel();
            model.Positions = positions;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsPlayer(CreatePlayerInputModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid registration attempt");

                var positions = new List<PositionViewModel>()
                {
                    new PositionViewModel()
                    {
                        Position = "GoalKeeper"
                    },
                    new PositionViewModel()
                    {
                        Position = "FieldPlayer"
                    },
                };

                model.Positions = positions;
                var errors = new StringBuilder();

                foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)) 
                {
                    errors.AppendLine(error.ToString());
                }

                return Ok(errors.ToString());
                //return View(model);
            }

            await _accountService.RegisterUser(model);

            return RedirectToAction("CreatePlayer", "Player", model);
        }
    }
}

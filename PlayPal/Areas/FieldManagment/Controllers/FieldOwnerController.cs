using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Extensions;

namespace PlayPal.Areas.FieldManagment.Controllers
{
    [Area("FieldManagment")]
    [Authorize(Policy = PlayPalPolicyNames.FieldManagment)]
    public class FieldOwnerController : PlayPalBaseController
    {
        private readonly IFieldOwnerService _fieldOwnerService;
        private readonly SignInManager<PlayPalUser> _signInManager;

        public FieldOwnerController(
            IFieldOwnerService fieldOwnerService,
            SignInManager<PlayPalUser> signInManager)
        {
            _fieldOwnerService = fieldOwnerService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            Guid fieldOwnerId = (Guid)User.OwnerId()!;

            try
            {
                var model = await _fieldOwnerService.GetFieldOwnerProfileViewModelAsync(fieldOwnerId);

                if (model == null)
                {
                    return RedirectToAction("Error", "Home", new { Area = "" });
                }

                return View(model);
            }
            catch (Exception)
            {
                ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;

                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            Guid fieldOwnerId = (Guid)User.OwnerId()!;
            string email = User.Identity!.Name!;

            try
            {
               var model = await _fieldOwnerService.GetEditFieldOwnerProfileInputModelAsync(fieldOwnerId, email);

                return View(model);
            }
            catch (Exception)
            {
                ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;

                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditFieldOwnerProfileInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                Guid userId = User.UserId();
                await _signInManager.SignOutAsync();

                await _fieldOwnerService.UpdateFieldOwnerAsync(model, userId);

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
            catch (Exception)
            {
                ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;

                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }
    }
}

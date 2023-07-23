using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services;
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
                var fieldOwner = await _fieldOwnerService.GetFieldOwnerAsync(fieldOwnerId);

                if (fieldOwner == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                var model = new FieldOwnerProfileViewModel()
                {
                    Id = fieldOwnerId,
                    FirstName = fieldOwner.FirstName,
                    LastName = fieldOwner.LastName,
                    Title = fieldOwner.Title.ToString(),
                    CompanyName = fieldOwner.CompanyName,
                    ContactAddress = fieldOwner.ContactAddress,
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
            Guid fieldOwnerId = (Guid)User.OwnerId()!;

            try
            {
                var fieldOwner = await _fieldOwnerService.GetFieldOwnerAsync(fieldOwnerId);

                var model = new EditFieldOwnerProfileInputModel()
                {
                    Email = User.Identity!.Name!,
                    Id = fieldOwnerId,
                    FirstName = fieldOwner.FirstName,
                    LastName = fieldOwner.LastName,
                    CompanyName = fieldOwner.CompanyName,
                    ContactAddress = fieldOwner.ContactAddress,
                    Title = fieldOwner.Title.ToString()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                throw;
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
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

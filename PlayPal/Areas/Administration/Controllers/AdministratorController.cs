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

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AdministratorController : PlayPalBaseController
    {
        private readonly IAdministratorService _administratorService;
        private readonly SignInManager<PlayPalUser> _signInManager;

        public AdministratorController(
            IAdministratorService administratorService,
            SignInManager<PlayPalUser> signInManager)
        {
            _administratorService = administratorService;
            _signInManager = signInManager;
        }

        [Authorize(Roles = PlayPalRoleNames.Administrator)]
        [HttpGet]
        public IActionResult Index()
        {
            if (User.HasClaim(c => c.Type == PlayPalClaimTypes.AdministratorId))
            {
                return RedirectToAction("All", "Report");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> Promote()
        {
            try
            {
                var appliedForAdministratorUsers = await _administratorService.GetAdministratorRequestsAsync();

                return View(appliedForAdministratorUsers);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpPost]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> Promote(string email, Guid administratorId)
        {
            try
            {
                var appliedForAdministratorUsers = await _administratorService.GetAdministratorRequestsAsync();

                if (appliedForAdministratorUsers.Any(u => u.Email == email && u.AdministratorId == administratorId))
                {
                    await _administratorService.PromoteUserToAdministrator(email, administratorId);
                }

                return RedirectToAction("Promote");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> ViewProfile()
        {
            Guid administratorId = (Guid)User.AdministratorId()!;

            Guid userId = User.UserId()!;

            try
            {
                var model = await _administratorService.GetAdministratorProfileViewModelAsync(administratorId, userId);

                if (model != null)
                {
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Error", "Homme", new {Area = ""});
                }
                
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }


        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> EditProfile()
        {
            Guid administratorId = (Guid)User.AdministratorId()!;

            string email = User.Identity!.Name!;

            try
            {
                var model = await _administratorService.GetEditAdministratorProfileInputModelAsync(administratorId, email);

                if (model == null)
                {
                    return RedirectToAction("Error", "Home", new { Area = "" });
                }

                return View(model);
            }
            catch (Exception) 
            { 
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpPost]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> EditProfile(EditAdministratorProfileInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                Guid userId = User.UserId();
                await _signInManager.SignOutAsync();

                await _administratorService.UpdateAdministratorAsync(model, userId);

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
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }
    }
}

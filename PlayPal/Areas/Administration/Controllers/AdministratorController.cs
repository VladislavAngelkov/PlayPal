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
                return RedirectToAction("Promote");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> Promote()
        {
            var appliedForAdministratorUsers = await _administratorService.GetAdministratorRequestsAsync();

            return View(appliedForAdministratorUsers);
        }

        [HttpPost]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> Promote(string email, Guid administratorId)
        {
            var appliedForAdministratorUsers = await _administratorService.GetAdministratorRequestsAsync();

            if (appliedForAdministratorUsers.Any(u => u.Email == email  && u.AdministratorId  == administratorId))
            {
                await _administratorService.PromoteUserToAdministrator(email, administratorId);
            }

            return RedirectToAction("Promote");
        }

        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> ViewProfile()
        {
            Guid administratorId = (Guid)User.AdministratorId()!;

            try
            {
                var administrator = await _administratorService.GetAdministratorAsync(administratorId);

                if (administrator == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                var model = new AdministratorProfileViewModel()
                {
                    Id = administratorId,
                    FirstName = administrator.FirstName,
                    LastName = administrator.LastName,
                };

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> EditProfile()
        {
            Guid administratorId = (Guid)User.AdministratorId()!;

            try
            {
                var administrator = await _administratorService.GetAdministratorAsync(administratorId);

                var model = new EditAdministratorProfileInputModel()
                {
                    Email = User.Identity!.Name!,
                    Id = administratorId,
                    FirstName = administrator.FirstName,
                    LastName = administrator.LastName
                };

                return View(model);
            }
            catch (Exception ex)
            {
                throw;
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
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
